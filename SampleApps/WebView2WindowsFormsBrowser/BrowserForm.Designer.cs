// Copyright (C) Microsoft Corporation. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System;

namespace WebView2WindowsFormsBrowser
{
    partial class BrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEvents = new System.Windows.Forms.Button();
            this.webView2Control = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.SuspendLayout();
            // 
            // btnEvents
            // 
            this.btnEvents.Location = new System.Drawing.Point(788, 25);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(75, 23);
            this.btnEvents.TabIndex = 6;
            this.btnEvents.Text = "Events";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // webView2Control
            // 
            this.webView2Control.Location = new System.Drawing.Point(0, -1);
            this.webView2Control.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webView2Control.Name = "webView2Control";
            this.webView2Control.Size = new System.Drawing.Size(789, 450);
            this.webView2Control.Source = new System.Uri("https://www.bing.com/", System.UriKind.Absolute);
            this.webView2Control.TabIndex = 7;
            this.webView2Control.Text = "webView2Control";
            this.webView2Control.ZoomFactor = 1D;
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 450);
            this.Controls.Add(this.webView2Control);
            this.Controls.Add(this.btnEvents);
            this.KeyPreview = true;
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BrowserForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrowserForm_KeyDown);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnEvents;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Control;
    }
}

