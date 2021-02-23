<%@ Page Title="Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Calculator.aspx.cs" Inherits="MegarenderTest.Calculator" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-left">
        <p>
        <asp:TextBox ID="txt1" runat="server" Height="30px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="result" runat="server" style="margin-top: 0px" Width="30px"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Button ID="calculate" runat="server" Text="=" Width="50px" OnClick="calculate_Click" />
        </p>
        <br />
        <p>
            &nbsp;</p>
        <p>Поддерживаемые операции</p>
        <ul>
            <li>Синус - sin</li>
            <li>Косинус - cos</li>
            <li>Тангенс - tan</li>
            <li>Котангенс - ctan</li>
            <li>Умножение - "*"</li>
            <li>Деление - "/"</li>
            <li>Сложение "+"</li>
            <li>Вычитание - "-"</li>
            <li>Возведение в степень - "^"</li>
            <li>Остаток от деления - "%"</li>
        </ul>
        <p><a href="Default.aspx">Home</a></p>
        <br />
    </div>
</asp:Content>