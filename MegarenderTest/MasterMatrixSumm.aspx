<%@ Page Title="MasterMatrixSumm" Language="C#" MasterPageFile="~/MasterCalculator.Master" AutoEventWireup="true" 
    CodeBehind="MasterMatrixSumm.aspx.cs" Inherits="MegarenderTest.MasterMatrixSumm" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style= "background-color: #99FF66" id="MatrixB">
        <p>Матрица B</p>
        <p>
            <asp:TextBox ID="Matrix2_1" runat="server"></asp:TextBox>
            <asp:TextBox ID="Matrix2_2" runat="server"></asp:TextBox>
            <asp:TextBox ID="Matrix2_3" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="Matrix2_4" runat="server"></asp:TextBox>
            <asp:TextBox ID="Matrix2_5" runat="server"></asp:TextBox>
            <asp:TextBox ID="Matrix2_6" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="Matrix2_7" runat="server"></asp:TextBox>
            <asp:TextBox ID="Matrix2_8" runat="server"></asp:TextBox>
            <asp:TextBox ID="Matrix2_9" runat="server"></asp:TextBox>
        </p>
    </div>
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ButtonZone" runat="server">

    <asp:Button ID="Button1" runat="server" Text="=" OnClick="Button1_Click" Width="50px" />

</asp:Content>
