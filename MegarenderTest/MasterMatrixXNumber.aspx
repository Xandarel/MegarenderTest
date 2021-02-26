<%@ Page Title="MasterMatrixXNumber" Language="C#" MasterPageFile="~/MasterCalculator.Master" AutoEventWireup="true" 
    CodeBehind="MasterMatrixXNumber.aspx.cs" Inherits="MegarenderTest.MasterMatrixXNumber" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style= "background-color: #FF9966" id="MatrixB">
        <p>Число</p>
        <p>
            <asp:TextBox ID="Number" runat="server"></asp:TextBox>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ButtonZone" runat="server">

    <asp:Button ID="Button1" runat="server" Text="=" OnClick="Button1_Click" Width="50px" />

</asp:Content>
