using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public partial class Form1 : Form
    {
        private readonly string INTROSPECT_V8 = "introspect-8.0.0.json";
        //private readonly string INTROSPECT_V6 = "introspect-6.32.5.json";
        private IntrospectResult result = null;
        private List<string> namespaces = null;
        private IntrospectSet<Method> methodSet = new IntrospectSet<Method>("Methods");
        private IntrospectSet<IntrospectType> typeSet = new IntrospectSet<IntrospectType>("Global Types");
        private IntrospectSet<Notification> notificationSet = new IntrospectSet<Notification>("Notifications");

        private Group<Method> methodGroup;
        private Group<Notification> notificationGroup;
        private Group<IntrospectType> typeGroup;

        public Form1()
        {
            InitializeComponent();

            // For rogue "$ref" items
            // per http://stackoverflow.com/a/22308790
            var settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore
            };

            var resourceLocation = Assembly.GetExecutingAssembly().GetName().Name;
            var serializer = JsonSerializer.Create(settings);
            
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                resourceLocation + "." + INTROSPECT_V8)
                )
            using (StreamReader reader = new StreamReader(stream))
            using (var jr = new JsonTextReader(reader))
            {
                result = serializer.Deserialize<IntrospectResponse>(jr).result;
            }

            var list = result.methods.Keys.Select(k => k.Substring(0, k.IndexOf("."))).Distinct().ToList();
            namespaces = list.OrderBy(i => i).ToList();
            this.comboBoxNamespaces.Items.AddRange(namespaces.ToArray());

            foreach (var ns in namespaces)
            {
                methodSet.Add(ns, new Group<Method>());
                notificationSet.Add(ns, new Group<Notification>());
                //AppendText(ns+"\n");
            }
            foreach (var item in result.methods)
            {
                int i = item.Key.IndexOf(".");
                var ns = item.Key.Substring(0, i);
                var method_name = item.Key.Substring(i+1);
                methodSet[ns].Add(method_name, item.Value);                
            }

            // TYPES
            var resultTypes = result.types.Keys;
            list = resultTypes.Select(k => k.Substring(0, k.Contains(".")?k.IndexOf("."):k.Length)
                                        ).Distinct().ToList().OrderBy(i => i).ToList();
            this.comboBoxTypeNamespaces.Items.AddRange(list.ToArray());
            foreach (var ns in list)
            {
                typeSet.Add(ns, new Group<IntrospectType>());
            }
            foreach (var item in result.types)
            {
                int i = item.Key.IndexOf(".");
                string ns = "";
                if (i <= 0)
                    ns = item.Key;
                else
                    ns = item.Key.Substring(0, i);
                var type_name = item.Key.Substring(i + 1);

                // Add property names
                var properties = item.Value.Properties;
                if (properties != null)
                {
                    foreach (var prop in properties)
                    {
                        prop.Value.Name = prop.Key;
                    }
                }
                typeSet[ns].Add(type_name, item.Value);
            }

            //NOTIFICATIONS
            foreach (var item in result.notifications)
            {
                int i = item.Key.IndexOf(".");
                var ns = item.Key.Substring(0, i);
                var notification_name = item.Key.Substring(i + 1);
                notificationSet[ns].Add(notification_name, item.Value);
            }


        }

        #region Cross Thread UI update
        delegate void AppendTextCallback(string text);

        private void AppendText(string text, params object[] args)
        {
            AppendText(string.Format(text, args));
        }


        private void AppendText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.AppendText(text);
            }
        }

        #endregion


        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void comboBoxNamespaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ns = this.comboBoxNamespaces.SelectedItem.ToString();
            methodGroup = methodSet[ns];
            notificationGroup = notificationSet[ns];
            this.comboBoxMethods.Items.Clear();
            this.comboBoxMethods.Items.AddRange(methodGroup.Items.ToArray());
            this.comboBoxNotifications.Items.Clear();
            this.comboBoxNotifications.Items.AddRange(notificationGroup.Items.ToArray());
            
        }

        private void comboBoxMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            var method = methodGroup[this.comboBoxMethods.SelectedItem.ToString()];
            AppendText(method.ToString());
        }

        private void comboBoxTypeNamespaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ns = this.comboBoxTypeNamespaces.SelectedItem.ToString();
            typeGroup = typeSet[ns];
            this.comboBoxTypes.Items.Clear();
            this.comboBoxTypes.Items.AddRange(typeGroup.Items.ToArray());
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            var type = typeGroup[this.comboBoxTypes.SelectedItem.ToString()];
            AppendText(type.ToString());
        }

        private void comboBoxNotifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            var notification = notificationGroup[this.comboBoxNotifications.SelectedItem.ToString()];
            AppendText(notification.ToString());
        }


        private void buttonAllMethods_Click(object sender, EventArgs e)
        {
            AppendText(methodSet.ToString());
        }
        private void buttonAllTypes_Click(object sender, EventArgs e)
        {
            AppendText(typeSet.ToString());
        }

        private void buttonAllNotifications_Click(object sender, EventArgs e)
        {
            AppendText(notificationSet.ToString());
        }

        private void buttonEverything_Click(object sender, EventArgs e)
        {
            AppendText(methodSet.ToString());
            AppendText(typeSet.ToString());
            AppendText(notificationSet.ToString());
        }



    }
}
