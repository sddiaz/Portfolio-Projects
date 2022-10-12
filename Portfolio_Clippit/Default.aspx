<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Testing._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form novalidate runat="server">
    <header class="title">
        Clippit
    </header>
     <asp:TextBox runat="server" id="pasteBox" contenteditable="true" CssClass="pasteBoxClass">

    </asp:TextBox>
    <div runat="server" class="row">
        <div runat="server" class="codeSection">
                <asp:ScriptManager ID="ScriptManager" runat="server"/>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>            
                        <asp:Button  Text="Get My Code" OnClick="GetCode_Click" runat="server" CssClass="codeGenerator"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
        <div runat="server" class="alignRight">
            <div runat="server" class="form">
                <input runat="server" maxlength="4" type="text" name="text" required />
                <label runat="server" for="text" class="label-name">
                    <span runat="server" class="content-name">
                        Your Code Here
                    </span>
                </label>
            </div>
        </div>
    </div>
    <asp:TextBox runat="server" id="copyBox" contenteditable="true" data-text="Copy Stuff Here" CssClass="pasteBoxClass lower">
    </asp:TextBox>
        </form>
</asp:Content>
