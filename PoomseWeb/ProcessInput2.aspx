<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProcessInput2.aspx.vb" Inherits="PoomseWeb.ProcessInput2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">

        .Button1
        {
            width: 100px;
            height: 90px;
            font-family: 'Angsana New';
			font-size: 40px; 
			font-weight: normal; 
			background-color: #0000FF; 
			color: #FFFF00;
        }
        .PreButtonAuter1
        {
            width: 100px;
            height: 90px;
            font-family: 'Angsana New';
			font-size: 40px; 
			font-weight: bold; 
			background-color: #FF0000; 
			color: #FFFF00;
        }
        .PreButtonAuter2
        {
            width: 100px;
            height: 90px;
            font-family: 'Angsana New';
			font-size: 40px; 
			font-weight: bold; 
			background-color: #FF0000; 
			color: #FFFFFF;
        }
        
        .AccButtonAuter1
        {
            width: 100px;
            height: 90px;
            font-family: 'Angsana New';
			font-size: 40px; 
			font-weight: bold; 
			background-color: #0000FF; 
			color: #FFFF00;
        }
        
        .AccButtonAuter2
        {
            width: 100px;
            height: 90px;
            font-family: 'Angsana New';
			font-size: 40px; 
			font-weight: bold; 
			background-color: #0000FF; 
			color: #FFFFFF;
        }
        
        .AccClearAuther1
        {
            font-family: 'Angsana New';
            font-size: 40px; 
            font-weight: normal; 
            color: #FFFF00; 
            background-color: #0000FF;
            text-align: center;
            width:160px;
            height:112px;
        }
        .AccClearAuther2
        {
            font-family: 'Angsana New';
            font-size: 40px; 
            font-weight: normal; 
            color: #FFFFFF; 
            background-color: #0000FF;
            text-align: center;
            width:160px;
            height:112px;
        }
        .PreClearAuther1
        {
        	font-family: 'Angsana New';
            font-size: 40px; 
            font-weight: normal; 
            color: #FFFF00; 
            background-color: #FF0000;
            text-align: center;
            width:160px;
            height:112px;
        }
        .PreClearAuther2
        {
        	font-family: 'Angsana New';
            font-size: 40px; 
            font-weight: normal; 
            color: #FFFFFF; 
            background-color: #FF0000;
            text-align: center;
            width:160px;
            height:112px;
        }

                    
        
  
        .style4
        {
            width: 182px;
        }
        .style6
        {
            width: 322px;
        }
        .style7
        {
            width: 249px;
        }
        .style8
        {
            width: 136px;
        }
        .AccShow
        {
        	width: 150px;
        }
        .AccAuther1
        {
            display: inline;
            margin:30px;
        }
        .AccAuther2
        {
        	display: inline;
        	margin:30px;
        }
    </style>

    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {
            var Auther1 = 1;
            var Auther2 = 2;
            var Auther1_Acc;
            var Auther2_Acc;

            var Auther1_AccOrigin;
            var Auther2_AccOrigin;

            var Auther1_Pre;
            var Auther2_Pre;

            var Auther1_PreOrigin;
            var Auther2_PreOrigin;

            var CurrentDate = null;
            var txtAccAuther1 = $("#<%=lblAccAuther1.ClientID %>");
            var txtAccAuther2 = $("#<%=lblAccAuther2.ClientID %>");
            var txtPreAuther1 = $("#<%=lblPreAuther1.ClientID %>");
            var txtPreAuther2 = $("#<%=lblPreAuther2.ClientID %>");
            var txtTotalAuther1 = $("#<%=lblTotalAuther1.ClientID %>");
            var txtTotalAuther2 = $("#<%=lblTotalAuther2.ClientID %>");
            var edit = 0;

            //-----------------------------------
            // Setup Initl Auther 1
            //-----------------------------------
            Auther1_Acc = parseFloat(txtAccAuther1.text());
            Auther1_AccOrigin = parseFloat(txtAccAuther1.text());
            Auther1_Pre = parseFloat(txtPreAuther1.text());
            Auther1_PreOrigin = parseFloat(txtPreAuther1.text());
            //-----------------------------------
            // Setup Initl Auther 2
            //-----------------------------------
            Auther2_Acc = parseFloat(txtAccAuther2.text());
            Auther2_AccOrigin = parseFloat(txtAccAuther2.text());
            Auther2_Pre = parseFloat(txtPreAuther2.text());
            Auther2_PreOrigin = parseFloat(txtPreAuther2.text());


            CurrentDate = setInterval(function() {

                var jude;

                jude = $("#<%=lblJudge.ClientID %>").text();

                if (edit == 1) {
                    getData = "Jude=" + jude;
                    getData += "&Auther1_Acc=" + Auther1_Acc + "&Auther1_Pre=" + Auther1_Pre;
                    getData += "&Auther2_Acc=" + Auther2_Acc + "&Auther2_Pre=" + Auther2_Pre;
                    
                    $("#div1").load("SendData.aspx?" + getData);
                    edit = 0;
                }
            }, 1000);



            $("#btnConfirm").click(

                function() {

                    if (window.confirm("Do you want to confirm?") == true) {
                        var jude;
                        jude = $("#<%=lblJudge.ClientID %>").text();
                        
                        getData = "Jude=" + jude;
                        getData += "&Auther1_Acc=" + Auther1_Acc + "&Auther1_Pre=" + Auther1_Pre;
                        getData += "&Auther2_Acc=" + Auther2_Acc + "&Auther2_Pre=" + Auther2_Pre;
                        $.ajax({
                            type: "POST",
                            url: "confirm.aspx?" + getData,
                            data: '{Jude:"' + jude + '",Auther1_Acc:' + Auther1_Acc + ',Auther1_Pre:' + Auther1_Pre + '",Auther2_Acc:' + Auther2_Acc + ',Auther2_Pre:' + Auther2_Pre + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(txt) {
                                //alert(txt);
                            }
                        });
                    }
                }
            );

            //---------------------------
            // Function For Set Acc Value
            //---------------------------
            function setAcc(Auther, AccValue) {
                if (Auther === Auther1) {
                    Auther1_Acc = Auther1_Acc + AccValue;
                    if (Auther1_Acc > Auther1_AccOrigin) {
                        Auther1_Acc = Auther1_AccOrigin;
                    }
                    txtAccAuther1.text(Number(Auther1_Acc).toFixed(2));
                    txtTotalAuther1.text(Number(Auther1_Acc + Auther1_Pre).toFixed(2));
                }
                if (Auther === Auther2) {
                    Auther2_Acc = Auther2_Acc + AccValue;
                    if (Auther2_Acc > Auther2_AccOrigin) {
                        Auther2_Acc = Auther2_AccOrigin;
                    }
                    txtAccAuther2.text(Number(Auther2_Acc).toFixed(2));
                    txtTotalAuther2.text(Number(Auther2_Acc + Auther2_Pre).toFixed(2));
                }
                edit = 1;
            }

            //---------------------------
            // Function For Set Pre Value
            //---------------------------
            function setPre(Auther, PreValue) {
                if (Auther === Auther1) {
                    Auther1_Pre = Auther1_Pre + PreValue;
                    if (Auther1_Pre > Auther1_PreOrigin) {
                        Auther1_Pre = Auther1_PreOrigin;
                    }
                    txtPreAuther1.text(Number(Auther1_Pre).toFixed(2));
                    txtTotalAuther1.text(Number(Auther1_Acc + Auther1_Pre).toFixed(2));
                }
                if (Auther === Auther2) {
                    Auther2_Pre = Auther2_Pre + PreValue;
                    if (Auther2_Pre > Auther2_PreOrigin) {
                        Auther2_Pre = Auther2_PreOrigin;
                    }
                    txtPreAuther2.text(Number(Auther2_Pre).toFixed(2));
                    txtTotalAuther2.text(Number(Auther2_Acc + Auther2_Pre).toFixed(2));
                }
                edit = 1;
            }

            //---------------------------
            // Auther 1 Event Click 
            //---------------------------
            $("#btnAccAuth1_p_1").click(
                function() {
                    setAcc(Auther1, +0.1);
                }
            );


            $("#btnAccAuth1_m_1").click(
                function() {
                    setAcc(Auther1, -0.1);
                }
            );

            $("#btnAccAuth1_m_3").click(
                function() {
                    setAcc(Auther1, -0.3);
                }
            );

            $("#btnPreAuth1_p_1").click(
                function() {
                    setPre(Auther1, +0.1);
                }
            );

            $("#btnPreAuth1_m_1").click(
                function() {
                    setPre(Auther1, -0.1);
                }
            );

            $("#btnPreAuth1_m_3").click(
                function() {
                    setPre(Auther1, -0.3);
                }
            );

            $('#btnAccClearAuther1').click(
                function() {
                    setAcc(Auther1, Auther1_AccOrigin);
                }
            );

            $('#btnPreClearAuther1').click(
                function() {
                    setPre(Auther1, Auther1_PreOrigin);
                }
            );
            //---------------------------
            // Auther 2 Event Click 
            //---------------------------
            $("#btnAccAuth2_p_1").click(
                function() {
                    setAcc(Auther2, +0.1);
                }
            );


            $("#btnAccAuth2_m_1").click(
                function() {
                    setAcc(Auther2, -0.1);
                }
            );

            $("#btnAccAuth2_m_3").click(
                function() {
                    setAcc(Auther2, -0.3);
                }
            );

            $("#btnPreAuth2_p_1").click(
                function() {
                    setPre(Auther2, +0.1);
                }
            );

            $("#btnPreAuth2_m_1").click(
                function() {
                    setPre(Auther2, -0.1);
                }
            );

            $("#btnPreAuth2_m_3").click(
                function() {
                    setPre(Auther2, -0.3);
                }
            );

            $('#btnAccClearAuther2').click(
                function() {
                    setAcc(Auther2, Auther2_AccOrigin);
                }
            );

            $('#btnPreClearAuther2').click(
                function() {
                    setPre(Auther2, Auther2_PreOrigin);
                }
            );

        });


    </script>

</head>
<body style="background-color: #000000">
    <form id="form1" runat="server">
    <div>
        <table>
           <%-- <!-- Auther Name -->
            <tr>
                <td style="font-family: Tahoma; color: #0000FF; text-align: center; font-size: 36px;" class="style6">
                    <asp:Label ID="Auther1" runat="server" Text="4.0" Font-Size="40pt" ForeColor="Gold"></asp:Label>
                </td>
                <td class="style8">
                </td>
                <td style="color: #FF0000; text-align: center; font-size: 36px;" class="style7">
                    <asp:Label ID="Auther2" runat="server" Text="4.0" Font-Size="40pt" ForeColor="white"></asp:Label>
                </td>
            </tr>--%>
            
            <tr>
                <td style="font-family: Tahoma; color: #0000FF; text-align: center; font-size: 36px;"
                    class="style6">
                    ACCURACY
                </td>
                <td class="style8">
                </td>
                <td style="color: #FF0000; text-align: center; font-size: 36px;" class="style7">
                    PRESENTATION
                </td>
            </tr>
            <tr>
                <!-- Display Total Scroe -->
                <td style="background-color: #0000FF; color: #FFFF00; " class="AccShow">
                    <div class="AccAuther1">
                    <asp:Label ID="lblAccAuther1" runat="server" Text="4.0" Font-Size="40pt" ForeColor="Gold"></asp:Label>
                    </div>
                    <div class="AccAuther2">
                    <asp:Label ID="lblAccAuther2" runat="server" Text="4.0" Font-Size="40pt" ForeColor="white"></asp:Label>
                    </div>
                </td>
                <td class="style8">
                </td>
                <td style="text-align: center; background-color: #FF0000;" class="style7">
                    <div class="AccAuther1">
                    <asp:Label ID="lblPreAuther1" runat="server" Text="6.0" Font-Size="40pt" ForeColor="Gold"></asp:Label>
                    </div>
                    <div class="AccAuther2">
                    <asp:Label ID="lblPreAuther2" runat="server" Text="6.0" Font-Size="40pt" ForeColor="white"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="height: 3px">
                <td colspan="3">
                </td>
            </tr>
            
            <!-- ------------------------------------------ -->
            <!-- FOr Auther 1                               -->
            <!-- ------------------------------------------ -->
            <tr>
                <!-- Button +1, -1, -3 -->
                <td class="style6">
                    <table>
                        <tr>
							<td style="width: 30%">
								<input type="button" id="btnAccAuth1_p_1" value="+0.1" class="AccButtonAuter1"  />
							</td>
							<td style="width: 5%">
                            </td>
                            <td style="width: 30%">
                                <input type="button" id="btnAccAuth1_m_1" value="-0.1" class="AccButtonAuter1"  />
                            </td>
                            <td style="width: 5%">
                            </td>
                            <td style="width: 30%">
                                <input type="button" id="btnAccAuth1_m_3" value="-0.3" class="AccButtonAuter1" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style8">
                <!-- Total Auther 1 -->
                <table>
                <tr>
                <td colspan="2" class="style4" style="text-align: center">
                <asp:Label ID="lblTotalAuther1" runat="server" Text="10.0" Font-Size="40pt" ForeColor="Yellow"></asp:Label>
                </td>
                </tr>
                </table>
                <!-- Total Auther 1 -->
                </td>
                <td class="style7">
                    <table>
                        <tr>
							<td style="width: 40%">
							    <input type="button" id="btnPreAuth1_p_1" value="+0.1" class="PreButtonAuter1"  />
                                
                            </td>
                            <td style="width: 10%">
                            <td style="width: 40%">
                                <input type="button" id="btnPreAuth1_m_1" value="-0.1" class="PreButtonAuter1"  />
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 40%">
                                <input type="button" id="btnPreAuth1_m_3" value="-0.3" class="PreButtonAuter1"  />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <!-- ------------------------------------------ -->
            <!-- FOr Auther 2                               -->
            <!-- ------------------------------------------ -->
            <tr>
                <td class="style6">
                    <table>
                        <tr>
							<td style="width: 50%">
								<input type="button" id="btnAccAuth2_p_1" value="+0.1" class="AccButtonAuter2" />
							</td>
                            <td style="width: 10%">
                                <input type="button" id="btnAccAuth2_m_1" value="-0.1" class="AccButtonAuter2" />
                            </td>
                            <td style="width: 10%">
                            </td>
                            <td style="width: 30%">
                                <input type="button" id="btnAccAuth2_m_3" value="-0.3" class="AccButtonAuter2" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style8">
                <!-- Total Auther 2 -->
                <table>
                <tr>
                <td colspan="2" class="style4" style="text-align: center">
                <asp:Label ID="lblTotalAuther2" runat="server" Text="10.0" Font-Size="40pt" ForeColor="#FFFFFF"></asp:Label>
                </td>
                </tr>
                </table>
                </td>
                <!-- Total Auther 2 -->
                <td class="style7">
                    <table>
                        <tr>
							<td style="width: 40%">
                                <input type="button" id="btnPreAuth2_p_1" value="+0.1" class="PreButtonAuter2" />
                            </td>
                            <td style="width: 10%">
                            <td style="width: 40%">
                                <input type="button" id="btnPreAuth2_m_1" value="-0.1" class="PreButtonAuter2" />
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 40%">
                                <input type="button" id="btnPreAuth2_m_3" value="-0.3" class="PreButtonAuter2" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style6">
                </td>
                <td class="style8">
                
                </td>
                <td class="style7">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <table>
                    <tr>
                    <td>
                    <input type="button" id="btnAccClearAuther1" value="Clear" class="AccClearAuther1" />
                    </td>
                    <td>
                    <input type="button" id="btnAccClearAuther2" value="Clear" class="AccClearAuther2" />
                    </td>
                    </tr>
                    </table>
                    
                    
                </td>
                <td class="style8">
                   
                </td>
                <td class="style7">
                    <table>
                    <tr>
                    <td>
                    <input type="button" id="btnPreClearAuther1" value="Clear" class="PreClearAuther1" />
                    </td>
                    <td>
                    <input type="button" id="btnPreClearAuther2" value="Clear" class="PreClearAuther2" />
                    </td>
                    </tr>
                    </table>

                </td>
            </tr>
            <tr>
                <td class="style6">
                    Judge :
                    <asp:Label ID="lblJudge" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style8">
                    &nbsp;
                    <input id="btnConfirm" style="font-family: 'Angsana New'; font-size: 40px; font-weight: normal;
                        width: 200px;" type="button" value="confirm" onclick="confirmClick" />
                </td>
            </tr>
        </table>
    </div>
    <div id="div1" />
    <div id="div2" />
    <%--  <asp:Timer ID="Timer1" runat="server" EnableViewState="False" Interval="1000">
    </asp:Timer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    </form>
</body>
</html>
