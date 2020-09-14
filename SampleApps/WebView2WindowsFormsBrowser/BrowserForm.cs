﻿// Copyright (C) Microsoft Corporation. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

//https://docs.microsoft.com/en-us/microsoft-edge/webview2/gettingstarted/winforms

using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace WebView2WindowsFormsBrowser
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
            HandleResize();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.Size = new System.Drawing.Size(1024, 768);
            this.Location = new System.Drawing.Point(0, 0);

            this.webView2Control.Source = new System.Uri("https://sandbox.prestige.de/displayengine.h5/testsapp/", System.UriKind.Absolute);
        }

        private void UpdateTitleWithEvent(string message)
        {
            string currentDocumentTitle = this.webView2Control?.CoreWebView2?.DocumentTitle ?? "Uninitialized";
            this.Text = currentDocumentTitle + " (" + message + ")";
        }

        #region Event Handlers
        private void WebView2Control_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            UpdateTitleWithEvent("NavigationStarting");
        }

        private void WebView2Control_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            UpdateTitleWithEvent("NavigationCompleted");
        }

        private void WebView2Control_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            //txtUrl.Text = webView2Control.Source.AbsoluteUri;
        }

        private void WebView2Control_CoreWebView2Ready(object sender, EventArgs e)
        {
            this.webView2Control.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
            this.webView2Control.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
            this.webView2Control.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            this.webView2Control.CoreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.Image);
            UpdateTitleWithEvent("CoreWebView2Ready");
        }

        private void WebView2Control_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateTitleWithEvent($"AcceleratorKeyUp key={e.KeyCode}");
        }

        private void WebView2Control_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateTitleWithEvent($"AcceleratorKeyDown key={e.KeyCode}");
        }

        private void CoreWebView2_HistoryChanged(object sender, object e)
        {
            // No explicit check for webView2Control initialization because the events can only start
            // firing after the CoreWebView2 and its events exist for us to subscribe.
            //btnBack.Enabled = webView2Control.CoreWebView2.CanGoBack;
            //btnForward.Enabled = webView2Control.CoreWebView2.CanGoForward;
            UpdateTitleWithEvent("HistoryChanged");
        }

        private void CoreWebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            //this.txtUrl.Text = this.webView2Control.Source.AbsoluteUri;
            UpdateTitleWithEvent("SourceChanged");
        }

        private void CoreWebView2_DocumentTitleChanged(object sender, object e)
        {
            this.Text = this.webView2Control.CoreWebView2.DocumentTitle;
            UpdateTitleWithEvent("DocumentTitleChanged");
        }
        #endregion

        #region UI event handlers
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            webView2Control.Reload();
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            //webView2Control.Source = new Uri(txtUrl.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webView2Control.GoBack();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            (new EventMonitor(this.webView2Control)).Show(this);
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webView2Control.GoForward();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            HandleResize();
        }

        private void xToolStripMenuItem05_Click(object sender, EventArgs e)
        {
            this.webView2Control.ZoomFactor = 0.5;
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.webView2Control.ZoomFactor = 1.0;
        }

        private void xToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.webView2Control.ZoomFactor = 2.0;
        }

        private void xToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Zoom factor: {this.webView2Control.ZoomFactor}", "WebView Zoom factor");
        }
        #endregion

        private void HandleResize()
        {
            // Resize the webview
            webView2Control.Size = this.ClientSize - new System.Drawing.Size(webView2Control.Location);

            // Move the Events button
            btnEvents.Left = this.ClientSize.Width - btnEvents.Width;
            //// Move the Go button
            //btnGo.Left = this.btnEvents.Left - btnGo.Size.Width;

            //// Resize the URL textbox
            //txtUrl.Width = btnGo.Left - txtUrl.Left;
        }

        private void BrowserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                webView2Control.Reload();
            }

            if (e.KeyCode == Keys.PageDown)
            {
                (new EventMonitor(this.webView2Control)).Show(this);
            }

            if (e.KeyCode == Keys.F2)
            {
                this.Close();
            }
        }
    }
}
