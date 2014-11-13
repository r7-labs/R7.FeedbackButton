//
// R7.FeedbackButton.ascx.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2014 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// TODO: Convert to DAL2

using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.UI.Skins;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;

namespace R7.FeedbackButton
{
    public partial class FeedbackButton : SkinObjectBase
    {
        #region Controls

        protected HyperLink linkFeedbackButton;

        #endregion

        #region Fields

        private string cssClass;

        private string target;

        private string resourceKey;

        private string localResourceFile = null;

        #endregion

        #region Properties

        public string CssClass
        {
            get
            {
                if (string.IsNullOrEmpty (cssClass))
                {
                    if (!string.IsNullOrEmpty (Attributes ["CssClass"]))
                        cssClass = Attributes ["CssClass"];
                    else
                        cssClass = "default-feedback-button";
                }

                return cssClass;        
            }
            set 
            { 
                cssClass = value;
            }
        }

        public int FeedbackTabId { get; set; }

        public string Target
        {
            get
            {
                if (string.IsNullOrEmpty (target))
                {
                    if (!string.IsNullOrEmpty (Attributes ["Target"]))
                        target = Attributes ["Target"];
                    else
                        target = "_blank";
                }

                return target;     
            }
            set
            { 
                target = value;
            }
        }

        public string ResourceKey
        {
            get
            {
                if (string.IsNullOrEmpty (resourceKey))
                {
                    if (!string.IsNullOrEmpty (Attributes ["ResourceKey"]))
                        resourceKey = Attributes ["ResourceKey"];
                    else
                        resourceKey = "FeedBackButton";
                }

                return resourceKey;     
            }
            set
            { 
                resourceKey = value;
            }
        }

        private string LocalResourceFile
        {
            get
            { 
                if (localResourceFile == null)
                    // NOTE: ASCX control name is needed!
                    localResourceFile = Localization.GetResourceFile (this, "R7.FeedbackButton.ascx");
                
                return localResourceFile; 
            }
        }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
           
            linkFeedbackButton.CssClass = Utils.FormatList (" ", CssClass, "unselectable");
            linkFeedbackButton.Target = Target;
            linkFeedbackButton.ToolTip = Localization.GetString (ResourceKey + ".Tooltip", LocalResourceFile);
            linkFeedbackButton.Text = Localization.GetString (ResourceKey + ".Text", LocalResourceFile);
        }
    }
}

