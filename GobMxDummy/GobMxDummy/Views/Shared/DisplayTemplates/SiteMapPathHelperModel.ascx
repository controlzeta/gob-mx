<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapPathHelperModel,MvcSiteMapProvider]]" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="MvcSiteMapProvider.Web.Html.Models" %>

<% foreach (var node in Model) { %>
    <% if (node != Model.Last()) { %>
        <li><%=Html.DisplayFor(m => node)%></li>
    <% } else { %>
        <li class="active"><%=Html.DisplayFor(m => node)%></li>
    <% } %>
<% } %>