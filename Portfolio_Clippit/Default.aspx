<%@ Page Title="Clippit - Online Clipboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Testing._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        textarea {
            resize: none; 
            overflow: hidden; 
        }
        .codeEntry {
            display: inline; 
            margin-top: 30px;
            padding: 10px;
            border-radius: 25px;
            background-color: #ff5455;
            border-color: white;
            color: white;
            font-family: Cocogoose;
            cursor: pointer;
            transition: 0.2s;
            box-shadow: 10px;
}

        .codeEntry:hover {
            background-color: #cc4344;
            transform: scale(1.1);
            color: white;
        }
        .input {
            font-family: Arial;
        }
        .codeLabel {
             margin-top: 30px;
             margin-left: 5px; 
             padding: 15px;
             border-radius: 25px;
             background-color: #ff5455;
             border-color: white;
             color: white;
             font-family: 'Arial Rounded MT';
             font-weight: bold; 
        }
        .Textbox {
            min-width:100%;
            padding: 25px;
        }
        .alignTextBoxes{
            display: flex; 
            align-items: center;
            justify-content: center; 
        }
    </style>
    <form novalidate runat="server">
    <header class="title">
        Clippit
    </header>
        <div runat="server" class="alignTextBoxes">
            <asp:TextBox onfocus="this.value=''" Text="◦ Enter Your Text &#10;◦ Generate Code &#10;◦ Paste Code and Retrieve Your Text!" Wrap="true" TextMode="MultiLine" runat="server" id="copyBox" contenteditable="true" CssClass="pasteBoxClass">
                </asp:TextBox>
        </div>
    <div runat="server" class="row">
        <div runat="server" class="codeSection">
                <asp:ScriptManager ID="ScriptManager" runat="server"/>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>            
                        <asp:Button UseSubmitBehavior="false" Text="Get My Code" OnClick="GetCode_Click" runat="server" CssClass="codeGenerator"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <asp:Label ID="codeLabel" Visible="false" Text="Your Code Is: 1234" runat="server" CssClass="codeLabel"></asp:Label>
        </div>
        <div runat="server" class="alignRight">
            <div runat="server" class="form">
                <input  style="font-family:'Arial Rounded MT'" runat="server" maxlength="4" type="text" id="userCodeHere" required />
                <label runat="server" for="text" class="label-name">
                    <span runat="server" class="content-name">
                        Your Code Here
                    </span>
                </label>
            </div>
            <div runat="server" class="codeSection">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>            
                        <asp:Button UseSubmitBehavior="false" Text="Confirm" OnClick="EnterCode" runat="server" CssClass="codeGenerator"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
        </div>
    </div>
        <div runat="server" class="alignTextBoxes">
    <asp:TextBox Wrap="true" TextMode="MultiLine" runat="server" id="pasteBox" contenteditable="true" data-text="Copy Stuff Here" CssClass="pasteBoxClass">
    </asp:TextBox>
            </div>
        </form>
</asp:Content>
