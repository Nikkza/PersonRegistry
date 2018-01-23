using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PersonRegistry
{
    public partial class Form1 : Form
    {
        public List<Person> persons = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddPersonsToList(TextBox f, TextBox l, List<Person> listpersons, ListBox listb, RadioButton rmale, RadioButton rfemale)
        {
            listb.SelectionMode = SelectionMode.MultiExtended;
            if (!(int.TryParse(f.Text, out int x) || int.TryParse(l.Text, out int y)))
            {
                if (!rfemale.Checked && !rmale.Checked)
                {
                    MessageBox.Show("you must enter (Firstname) and (Lastname) and choose (Male) or (Female) Gender");
                }

                if (rfemale.Checked)
                {
                    if (!String.IsNullOrEmpty(f.Text) && !String.IsNullOrEmpty(l.Text))
                    {
                        listb.Items.Clear();
                        listpersons.Add(new Female("Miss", f.Text, l.Text));

                        foreach (var i in persons)
                        {
                            listb.Items.Add(i.GetPersonInfo());
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must enter a (Name) and (Lastname)");
                    }
                }

                if (rmale.Checked)
                {
                    if (!String.IsNullOrEmpty(f.Text) && !String.IsNullOrEmpty(l.Text))
                    {
                        listb.Items.Clear();
                        listpersons.Add(new Male("Mr", f.Text, l.Text));

                        foreach (var i in persons)
                        {
                            listb.Items.Add(i.GetPersonInfo());
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must enter a (Name) and (Lastname)");
                    }
                }
                rmale.Checked = false;
                rfemale.Checked = false;
                f.Clear();
                l.Clear();
            }
            else
            {
                f.Clear();
                l.Clear();
                MessageBox.Show("You must type Alphbetical letter from  ( A - Ö )");
            }

        }

        private void ButtonAdd(object sender, EventArgs e)
        {
            AddPersonsToList(textBoxName, textboxlastname, persons, listBoxMember, radioButtonMale, radioButtonFemale);
        }

        public void PrintLists()
        {
            persons.Sort();
            foreach (var i in persons)
            {
                listBoxMember.Items.Add(i.GetPersonInfo());
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

            int indexnr;
            if (listBoxMember.SelectedItem == null)
            {
                MessageBox.Show("You must Selcted one item to Remove");
            }

            if (listBoxMember.SelectedIndex == -1)
            {
                indexnr = listBoxMember.SelectedIndex - 1;
            }
            else
            {
                indexnr = listBoxMember.SelectedIndex;
                listBoxMember.Items.Clear();
                persons.RemoveAt(indexnr);
                PrintLists();
            }
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            if (listBoxMember.Items.Count > 0)
            {
                listBoxMember.Items.Clear();
                PrintLists();

            }
            else
                MessageBox.Show("You can not sort a empty list");
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {

            if (listBoxMember.SelectedItems.Count == 2)
            {
                var indexnr = listBoxMember.SelectedIndices;
                var ch = persons[indexnr[0]] + persons[indexnr[1]];
                if (ch != null)
                {
                    persons.Add(ch);
                    listBoxMember.Items.Clear();
                    PrintLists();
                }
                else
                    MessageBox.Show("You must choose for merge (Miss and MR) or (Mr and Miss)");

                listBoxMember.ClearSelected();
            }
            else
                MessageBox.Show("You must Add 2 person or selected 2 peresons for merge (Miss and MR) or (Mr and Miss)");
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            listBoxMember.Items.Clear();
            var SearchString = Search.Text.ToLower();
            var query = persons.Where(b => b.CheckString(SearchString));

            foreach (var item in query)
            {
                listBoxMember.Items.Add(item.GetPersonInfo());
            }
        }
    }
}


