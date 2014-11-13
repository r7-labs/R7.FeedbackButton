<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.FeedbackButton.FeedbackButton" CodeBehind="R7.FeedbackButton.ascx.cs" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnJsInclude runat="server" FilePath="rangy/rangy-core.js" PathNameAlias="SharedScripts" />
<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/R7.FeedbackButton/R7.FeedbackButton/skinobject.css" />

<script type="text/javascript">
//<![CDATA[
function r7FeedbackButton (obj) {
    $(obj).attr ("href", "/Default.aspx?tabid=<%= FeedbackTabId %>&errortabid=<%= PortalSettings.ActiveTab.TabID %>");
    var errorContext = encodeURIComponent (rangy.getSelection ().toString ().replace (/(\n|\r)/gm," ").replace (/\s+/g, " ").replace (/\"/g, "").trim ().substring (0,100));
    if (!!errorContext)
        $(obj).attr ("href",  $(obj).attr ("href") + "&errorcontext=" + errorContext);
    return true;
}
//]]>
</script>

<asp:HyperLink id="linkFeedbackButton" runat="server" unselectable="true" onclick="javascript:return r7FeedbackButton(this)" />
