# About R7.FeedbackButton

*R7.FeedbackButton* is a skinobject extension for DNN Platform to use along with the popular 
[DNN Feedback](http://dnnfeedback.codeplex.com) module. 

It allows:

1. Easily navigate to feedback page from any website page.

2. Pass `errortabid` parameter in the querystring to indicate feedback source page.

3. Pass `errorcontext` parameter in the querystring with user-selected text to indicate feedback problem 
(using *rangy* JavaScript library).

4. Customize button look, link target, text &amp; tooltip localization. 

Note that *DNN Feedback* module stores entire URL with all querystring params in the UserAgent field, 
which is accessible from the *Feedback Comments* module by adding [Feedback:UserAgent] tag to the item template.

## Install 

Install [rangy](https://github.com/timdown/rangy/releases) scripts to `~/Resources/Shared/scripts/rangy/rangy-core.js`

Install latest *R7.FeedbackButton* release from *Host &gt; Extensions*.

Register control in the skin:

```
<%@ Register TagPrefix="r7" TagName="FeedbackButton" src="~/DesktopModules/R7.FeedbackButton/R7.FeedbackButton/R7.FeedbackButton.ascx" %> 
```

Add control entry to the skin file (default use):

```
<r7:FeedbackButton runat="server" FeedbackTabId="123" />
```

Note that `FeedbackTabId` value is required and must be set to the TabId of the page where DNN Feedback module is.

## Customizing

Custom CSS class, link target:

```
<r7:FeedbackButton runat="server" FeedbackTabId="123" CssClass="my-feedback-button" Target="my-feedback-frame" />
```

## Localization

You could change feedback button label and tooltip by editing `App_LocalResources/R7.FeedbackButton.ascx.resx` files
or add translation to other language by adding separate `resx` file for it. 

Use the `ResourceKey` property to specify other name for resource keys. 

```
<r7:FeedbackButton runat="server" FeedbackTabId="123" ResourceKey="MyFeedbackButton" />
```

In this example, control will try to load `MyFeedbackButton.Text` resource string for button label, 
and `MyFeedbackButton.Tooltip` resource string for tooltip text. 
