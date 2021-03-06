﻿/**
 * Copyright (c) 2015, OCEAN
 * All rights reserved.
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
 * 3. The name of the author may not be used to endorse or promote products derived from this software without specific prior written permission.
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

/**
 * Created by Chen Nan in KETI on 2016-07-28.
 */
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MobiusResourceMonitor_sub
{
    /// <summary>
    /// CreateGrpWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CreateGrpWindow : Window
    {
        public GroupObject GRP { get; set; }

        public CreateGrpWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtRN.Text.Trim().Length > 0 
                && this.txtMNM.Text.Length > 0
                && this.lstUrls.Items.Count > 0)
            {
                this.GRP = new GroupObject();
                this.GRP.RN = this.txtRN.Text;
                this.GRP.MNM = this.txtMNM.Text;

                List<string> lstNus = new List<string>();

                for (int i = 0; i < this.lstUrls.Items.Count; i++)
                {
                    lstNus.Add((this.lstUrls.Items[i] as ListBoxItem).Content.ToString());
                }

                this.GRP.MID = lstNus.ToArray();

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please input the necessary information for Group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtNewUrl.Text.Trim().Length > 0)
            {
                for (int i = 0; i < this.lstUrls.Items.Count; i++)
                {
                    if ((this.lstUrls.Items[i] as ListBoxItem).Content.ToString() == this.txtNewUrl.Text)
                    {
                        MessageBox.Show("This notification url is existed..!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        return;
                    }
                }

                ListBoxItem newItem = new ListBoxItem();
                newItem.Content = this.txtNewUrl.Text;

                this.lstUrls.Items.Add(newItem);

                this.txtNewUrl.Text = "";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstUrls.SelectedItem != null)
            {
                this.lstUrls.Items.Remove(this.lstUrls.SelectedItem);
            }
        }

        private void txtMNM_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (this.txtMNM.Text.Trim().Length > 0)
                {
                    int value = Convert.ToInt32(this.txtMNM.Text);
                }
            }
            catch
            {
                MessageBox.Show("Must be a number!");
                this.txtMNM.Text = "";
            }
        }
    }
}
