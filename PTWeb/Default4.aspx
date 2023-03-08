<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="dropzone">
        <form action="//dummy.html" class="dropzone">
            <div class="fallback">
                <input name="file" type="file" multiple="" />
            </div>
        </form>
    </div>
</asp:Content>

