<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProcessInput1.aspx.vb" Inherits="PoomseWeb.ProcessInput1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<style type="text/css">
		#btnAccPlus1
        {
            width: 100px;
            height: 112px;
        }
        #btnAcc1
        {
            width: 100px;
            height: 112px;
        }
        #btnAcc3
        {
            width: 100px;
            height: 112px;
        }
        #btnAccClear
        {
            width: 331px;
            height: 112px;
        }
		#btnPrePlus1
        {
            width: 100px;
            height: 112px;
        }
        #btnPre1
        {
            width: 100px;
            height: 112px;
        }
        #btnPre3
        {
            width: 100px;
            height: 112px;
        }
        #btnPreClear
        {
            width: 358px;
            height: 112px;
        }
        #Button1
        {
            width: 212px;
            height: 90px;
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
    </style>

    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {
            var Acc;
            var AccOrigin;
            var Pre;
            var PreOrigin;
            var CurrentDate = null;
            var txtAcc = $("#<%=lblAccAuther1.ClientID %>");
            var txtPre = $("#<%=lblPreAuther1.ClientID %>");
            var txtTotal = $("#<%=lblTotal.ClientID %>");
            var edit = 0;

			//alert(txtAcc.text());
            Acc = parseFloat(txtAcc.text());
            AccOrigin = parseFloat(txtAcc.text());
            Pre = parseFloat(txtPre.text());
            PreOrigin = parseFloat(txtPre.text());


            CurrentDate = setInterval(function() {

                var jude;
    
                jude = $("#<%=lblJudge.ClientID %>").text();

                if (edit == 1) {
                    getData = "Jude=" + jude;
                    getData += "&Auther1_Acc=" + Acc + "&Auther1_Pre=" + Pre;
                    getData += "&Auther2_Acc=0&Auther2_Pre=0";

                    $("#div1").load("SendData.aspx?" + getData);
                    
                    //$("#div1").load("SendData.aspx?Jude=" + jude + "&Acc=" + Acc + "&Pre=" + Pre);
                    edit = 0;
                }
            }, 1000);

            $("#btnConfirm").click(
				
                function() {
					
                    if (window.confirm("Do you want to confirm?") == true) {
                        var jude;
                        jude = $("#<%=lblJudge.ClientID %>").text();

                        getData = "Jude=" + jude;
                        getData += "&Auther1_Acc=" + Acc + "&Auther1_Pre=" + Pre;
                        getData += "&Auther2_Acc=0&Auther2_Pre=0" ;
                        $.ajax({
                            type: "POST",
                            url: "confirm.aspx?" + getData,
                            data: '{Jude:"' + jude + '",Auther1_Acc:' + Acc + ',Auther1_Pre:' + Pre + '",Auther2_Acc:0,Auther2_Pre:0}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(txt) {
                                //alert(txt);
                            }
                        });
                        
						
                    }
                }
            );
			
			$("#btnAccPlus1").click(
                  function() {
                      Acc = Acc + 0.1;
					  if (Acc > AccOrigin) {
						Acc = AccOrigin;
					  }
                      txtAcc.text(Number(Acc).toFixed(2));
                      txtTotal.text(Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } //end function
            ); // end click

            $("#btnAcc1").click(
                  function() {
                      Acc = Acc - 0.1;
					  if ( Acc < 0 ) {
						Acc = 0;
					  }
                      txtAcc.text(Number(Acc).toFixed(2));
                      txtTotal.text(Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } //end function
            ); // end click

            $("#btnAcc3").click(
                  function() {
                      Acc = Acc - 0.3;
					  if ( Acc < 0 ) {
						Acc = 0;
					  }
                      txtAcc.text(Number(Acc).toFixed(2));
                      txtTotal.text( Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } //end function
            ); // end click

            $("#btnAccClear").click(
                  function() {
                      Acc = AccOrigin;
                      txtAcc.text(Number(Acc).toFixed(2));
                      txtTotal.text(Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } //end function
            ); // end click

			$("#btnPrePlus1").click(
                  function() {
                      Pre = Pre + 0.1;
					  if (Pre > PreOrigin ) {
						Pre = PreOrigin;
					  }
                      txtPre.text(Number(Pre).toFixed(2));
                      txtTotal.text( Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } // end function
            ); // end click

            $("#btnPre1").click(
                  function() {
                      Pre = Pre - 0.1;
					  if (Pre < 0 ) {
						Pre = 0;
					  }
                      txtPre.text(Number(Pre).toFixed(2));
                      txtTotal.text( Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } // end function
            ); // end click

            $("#btnPre3").click(
                  function() {
                      Pre = Pre - 0.3;
					  if (Pre < 0 ) {
						Pre = 0;
					  }
                      txtPre.text(Number(Pre).toFixed(2));
                      txtTotal.text( Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } // end function
            ); // end click

            $("#btnPreClear").click(
                  function() {
                      Pre = PreOrigin;
                      txtPre.text(Pre);
                      txtTotal.text(Number(Acc + Pre).toFixed(2));
                      edit = 1;
                  } // end function
            ); // end click
        });


    </script>

</head>
<body style="background-color: #000000">
    <form id="form1" runat="server">
    <div>
        <table>
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
                <td style="background-color: #0000FF; color: #FFFF00; text-align: center;" class="style6">
                    <asp:Label ID="lblAccAuther1" runat="server" Text="4.0" Font-Size="40pt" ForeColor="Gold"></asp:Label>
                </td>
                <td class="style8">
                </td>
                <td style="text-align: center; background-color: #FF0000;" class="style7">
                    <asp:Label ID="lblPreAuther1" runat="server" Text="6.0" Font-Size="40pt" ForeColor="Gold"></asp:Label>
                </td>
            </tr>
            <tr style="height: 3px">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <table>
                        <tr>
							<td style="width: 50%">
								<input type="button" id="btnAccPlus1" value="+0.1" style="font-family: 'Angsana New';
										font-size: 40px; font-weight: normal; background-color: #0000FF; color: #FFFF00;"
										onclick="return btnAccPlus1_onclick()" />
							</td>
                            <td style="width: 10%">
                                <input type="button" id="btnAcc1" value="-0.1" style="font-family: 'Angsana New';
                                    font-size: 40px; font-weight: normal; background-color: #0000FF; color: #FFFF00;"
                                    onclick="return btnAcc1_onclick()" />
                            </td>
                            <td style="width: 10%">
                            </td>
                            <td style="width: 30%">
                                <input type="button" id="btnAcc3" value="-0.3" style="font-family: 'Angsana New';
                                    font-size: 40px; font-weight: normal; color: #FFFF00; background-color: #0000FF;" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style8">
                </td>
                <td class="style7">
                    <table>
                        <tr>
							<td style="width: 40%">
                                <input type="button" id="btnPrePlus1" value="+0.1" style="font-family: 'Angsana New';
                                    font-size: 40px; font-weight: normal; background-color: #FF0000; color: #FFFF00;
                                    text-align: center;" />
                            </td>
                            <td style="width: 10%">
                            <td style="width: 40%">
                                <input type="button" id="btnPre1" value="-0.1" style="font-family: 'Angsana New';
                                    font-size: 40px; font-weight: normal; background-color: #FF0000; color: #FFFF00;
                                    text-align: center;" />
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 40%">
                                <input type="button" id="btnPre3" value="-0.3" style="font-family: 'Angsana New';
                                    font-size: 40px; font-weight: normal; color: #FFFF00; background-color: #FF0000;
                                    text-align: center;" />
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
                    <input type="button" id="btnAccClear" value="Clear" style="font-family: 'Angsana New';
                        font-size: 40px; font-weight: normal; color: #FFFF00; background-color: #0000FF;
                        text-align: center;" />
                </td>
                <td class="style8">
                    <table>
                        <tr>
                            <td colspan="2" class="style4" style="text-align: center">
                                <asp:Label ID="lblTotal" runat="server" Text="10.0" Font-Size="40pt" ForeColor="Yellow"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style7">
                    <input type="button" id="btnPreClear" value="Clear" style="font-family: 'Angsana New';
                        font-size: 40px; font-weight: normal; color: #FFFF00; background-color: #FF0000;
                        text-align: center;" />
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Judge :
                    <asp:Label ID="lblJudge" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style8">
                    <%--  <asp:Button ID="btnConFirm" runat="server" Text="Comfirm" 
                    Height="82px" Width="435px" />--%>&nbsp;
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
