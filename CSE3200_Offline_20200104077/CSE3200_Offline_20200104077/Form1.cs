using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSE3200_Offline_20200104077
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.YellowGreen;
            radioButton2.ForeColor = Color.Red;

            cmb_items.Items.Clear();
            cmb_items.Items.Add("Fruits Item 1");
            cmb_items.Items.Add("Fruits Item 2");
            cmb_items.Items.Add("Fruits Item 3");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Red;
            radioButton2.ForeColor = Color.YellowGreen;

            cmb_items.Items.Clear();
            cmb_items.Items.Add("Vegetable Item 1");
            cmb_items.Items.Add("Vegetable Item 2");
            cmb_items.Items.Add("Vegetable Item 3");
        }

        private void cmb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_items.SelectedItem != null) // Check if an item is selected
            {
                string selectedItem = cmb_items.SelectedItem.ToString();

                if (selectedItem == "Fruits Item 1")
                {
                    txt_price.Text = "50";
                }
                else if (selectedItem == "Fruits Item 2")
                {
                    txt_price.Text = "100";
                }
                else if (selectedItem == "Fruits Item 3")
                {
                    txt_price.Text = "150";
                }
                else if (selectedItem == "Vegetable Item 1")
                {
                    txt_price.Text = "200";
                }
                else if (selectedItem == "Vegetable Item 2")
                {
                    txt_price.Text = "250";
                }
                else if (selectedItem == "Vegetable Item 3")
                {
                    txt_price.Text = "300";
                }
                else
                {
                    txt_price.Text = "0";
                }

                txt_total.Text = "";
                txt_qty.Text = "";
            }
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            if (txt_qty.Text.Length > 0)
            {
                txt_total.Text = (Convert.ToInt32(txt_qty.Text) * Convert.ToInt32(txt_price.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[4];
            arr[0] = cmb_items.SelectedItem.ToString();
            arr[1] = txt_price.Text;
            arr[2] = txt_qty.Text;
            arr[3] = txt_total.Text;

            ListViewItem lvi = new ListViewItem(arr);
            listView1.Items.Add(lvi);

            txt_sub.Text = (Convert.ToInt32(txt_sub.Text) + Convert.ToInt32(txt_total.Text)).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        txt_sub.Text = (Convert.ToInt32(txt_sub.Text) - Convert.ToInt32(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();
                    }
                }
            }
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text.Length > 0)
            {
                txt_net.Text = (Convert.ToInt32(txt_sub.Text) - Convert.ToInt32(txt_discount.Text)).ToString();
            }
        }

        private void txt_paid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_paid.Text))
            {
                if (int.TryParse(txt_paid.Text, out int paidAmount))
                {
                    txt_balance.Text = (Convert.ToInt32(txt_net.Text) - paidAmount).ToString();
                }
                else
                {
                    // Handle invalid input, such as displaying an error message
                    MessageBox.Show("Invalid paid amount. Please enter a valid integer.");
                    txt_paid.Clear();
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Clear all form fields and reset the state of the application
            cmb_items.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txt_price.Clear();
            txt_qty.Clear();
            txt_total.Clear();
            listView1.Items.Clear();
            txt_sub.Text = "0";
            txt_discount.Text = "0";
            txt_net.Text = "0";
            txt_paid.Clear();
            txt_balance.Clear();
        }


    }
}
