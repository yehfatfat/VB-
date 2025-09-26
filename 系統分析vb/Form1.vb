Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class LoginL
    Dim billy As Double = My.Computer.Screen.Bounds.Width / 1920
    Dim ds As New DataSet()
    Dim cmd As String
    Dim ccmd As New MySqlCommand
    Dim adpt As New MySqlDataAdapter
    Dim meals_amount As Integer
    Dim pages As Integer
    Dim actual_amount As Integer
    Dim meals_numbers(500) As Integer
    Dim totalmoney As Integer
    Dim order_amount As Integer
    Dim Date_now As DateTime = New DateTime
    Dim spicy As String
    Dim RndNum As New Random()
    Dim Naccount As String
    Dim Account As String
    Dim Infochangestr As String
    Dim Infoupdate As Boolean = False
    Dim Info_change(28, 2) As String
    Dim lb() As Byte
    Dim lstr As New System.IO.MemoryStream
    Dim str As String = "server=127.0.0.1;uid=root;pwd=;database=sa"
    Dim Conn As New MySqlConnection(str)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        pages = 1

        For i As Integer = 0 To 499
            meals_numbers(i) = 0
        Next
        date_now = Date.Now


#Region "主介面"
        Order_btn.Location = New Point(750 * billy, 600 * billy - 20)
        Setting_btn.Location = New Point(1790 * billy, 900 * billy - 20)
        Main_pic.Location = New Point(760 * billy, 100 * billy - 20)

        Order_btn.Size = New Size(440 * billy, 170 * billy)
        Setting_btn.Size = New Size(120 * billy, 110 * billy)
        Main_pic.Size = New Size(434 * billy, 498 * billy)

        Order_btn.Font = New Font(Order_btn.Font.Name, CSng(72 * billy), FontStyle.Bold)
#End Region

#Region "點餐介面"
        Order_left.Location = New Point(10 * billy, 300 * billy)
        Order_right.Location = New Point(1830 * billy, 300 * billy)
        Order_pagesL.Location = New Point(450 * billy, 920 * billy)
        Order_confirm_btn.Location = New Point(1400 * billy, 900 * billy)
        Order_back_btn.Location = New Point(1100 * billy, 900 * billy)

        Order_left.Size = New Size(80 * billy, 230 * billy)
        Order_right.Size = New Size(70 * billy, 230 * billy)
        Order_confirm_btn.Size = New Size(200 * billy, 100 * billy)
        Order_back_btn.Size = New Size(200 * billy, 100 * billy)

        Order_pagesL.Font = New Font(Order_pagesL.Font.Name, CSng(40 * billy), FontStyle.Bold)
        Order_confirm_btn.Font = New Font(Order_confirm_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Order_back_btn.Font = New Font(Order_back_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Food1_amount.Font = New Font(Food1_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food1_name.Font = New Font(Food1_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food1_price.Font = New Font(Food1_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food2_amount.Font = New Font(Food2_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food2_name.Font = New Font(Food2_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food2_price.Font = New Font(Food2_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food3_amount.Font = New Font(Food3_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food3_name.Font = New Font(Food3_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food3_price.Font = New Font(Food3_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food4_amount.Font = New Font(Food4_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food4_name.Font = New Font(Food4_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food4_price.Font = New Font(Food4_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food5_amount.Font = New Font(Food5_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food5_name.Font = New Font(Food5_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food5_price.Font = New Font(Food5_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food6_amount.Font = New Font(Food6_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food6_name.Font = New Font(Food6_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food6_price.Font = New Font(Food6_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food7_amount.Font = New Font(Food7_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food7_name.Font = New Font(Food7_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food7_price.Font = New Font(Food7_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food8_amount.Font = New Font(Food8_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food8_name.Font = New Font(Food8_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food8_price.Font = New Font(Food8_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food9_amount.Font = New Font(Food9_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food9_name.Font = New Font(Food9_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food9_price.Font = New Font(Food9_price.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food10_amount.Font = New Font(Food10_amount.Font.Name, CSng(32 * billy), FontStyle.Bold)
        Food10_name.Font = New Font(Food10_name.Font.Name, CSng(26 * billy), FontStyle.Bold)
        Food10_price.Font = New Font(Food10_price.Font.Name, CSng(26 * billy), FontStyle.Bold)


        Food1_pic.Location = New Point(110 * billy, 105 * billy - 20)
        Food1_minus.Location = New Point(110 * billy, 350 * billy - 20)
        Food1_amount.Location = New Point(190 * billy, 360 * billy - 20)
        Food1_plus.Location = New Point(280 * billy, 350 * billy - 20)
        Food1_name.Location = New Point(110 * billy, 55 * billy - 20)
        Food1_price.Location = New Point(240 * billy, 55 * billy - 20)

        Food1_pic.Size = New Size(240 * billy, 240 * billy)
        Food1_minus.Size = New Size(70 * billy, 70 * billy)
        Food1_amount.Size = New Size(80 * billy, 60 * billy)
        Food1_plus.Size = New Size(70 * billy, 70 * billy)
        Food1_name.Size = New Size(150 * billy, 50 * billy)
        Food1_price.Size = New Size(150 * billy, 50 * billy)

        Food2_pic.Location = New Point(475 * billy, 105 * billy - 20)
        Food2_minus.Location = New Point(475 * billy, 350 * billy - 20)
        Food2_amount.Location = New Point(555 * billy, 360 * billy - 20)
        Food2_plus.Location = New Point(645 * billy, 350 * billy - 20)
        Food2_name.Location = New Point(475 * billy, 55 * billy - 20)
        Food2_price.Location = New Point(600 * billy, 55 * billy - 20)

        Food2_pic.Size = New Size(240 * billy, 240 * billy)
        Food2_minus.Size = New Size(70 * billy, 70 * billy)
        Food2_amount.Size = New Size(80 * billy, 60 * billy)
        Food2_plus.Size = New Size(70 * billy, 70 * billy)
        Food2_name.Size = New Size(150 * billy, 50 * billy)
        Food2_price.Size = New Size(150 * billy, 50 * billy)

        Food3_pic.Location = New Point(840 * billy, 105 * billy - 20)
        Food3_minus.Location = New Point(840 * billy, 350 * billy - 20)
        Food3_amount.Location = New Point(920 * billy, 360 * billy - 20)
        Food3_plus.Location = New Point(1010 * billy, 350 * billy - 20)
        Food3_name.Location = New Point(840 * billy, 55 * billy - 20)
        Food3_price.Location = New Point(970 * billy, 55 * billy - 20)

        Food3_pic.Size = New Size(240 * billy, 240 * billy)
        Food3_minus.Size = New Size(70 * billy, 70 * billy)
        Food3_amount.Size = New Size(80 * billy, 60 * billy)
        Food3_plus.Size = New Size(70 * billy, 70 * billy)
        Food3_name.Size = New Size(150 * billy, 50 * billy)
        Food3_price.Size = New Size(150 * billy, 50 * billy)

        Food4_pic.Location = New Point(1205 * billy, 105 * billy - 20)
        Food4_minus.Location = New Point(1205 * billy, 350 * billy - 20)
        Food4_amount.Location = New Point(1285 * billy, 360 * billy - 20)
        Food4_plus.Location = New Point(1375 * billy, 350 * billy - 20)
        Food4_name.Location = New Point(1205 * billy, 55 * billy - 20)
        Food4_price.Location = New Point(1335 * billy, 55 * billy - 20)

        Food4_pic.Size = New Size(240 * billy, 240 * billy)
        Food4_minus.Size = New Size(70 * billy, 70 * billy)
        Food4_amount.Size = New Size(80 * billy, 60 * billy)
        Food4_plus.Size = New Size(70 * billy, 70 * billy)
        Food4_name.Size = New Size(150 * billy, 50 * billy)
        Food4_price.Size = New Size(150 * billy, 50 * billy)

        Food5_pic.Location = New Point(1570 * billy, 105 * billy - 20)
        Food5_minus.Location = New Point(1570 * billy, 350 * billy - 20)
        Food5_amount.Location = New Point(1650 * billy, 360 * billy - 20)
        Food5_plus.Location = New Point(1740 * billy, 350 * billy - 20)
        Food5_name.Location = New Point(1570 * billy, 55 * billy - 20)
        Food5_price.Location = New Point(1700 * billy, 55 * billy - 20)

        Food5_pic.Size = New Size(240 * billy, 240 * billy)
        Food5_minus.Size = New Size(70 * billy, 70 * billy)
        Food5_amount.Size = New Size(80 * billy, 60 * billy)
        Food5_plus.Size = New Size(70 * billy, 70 * billy)
        Food5_name.Size = New Size(150 * billy, 50 * billy)
        Food5_price.Size = New Size(150 * billy, 50 * billy)

        Food6_pic.Location = New Point(110 * billy, 500 * billy - 20)
        Food6_minus.Location = New Point(110 * billy, 745 * billy - 20)
        Food6_amount.Location = New Point(190 * billy, 755 * billy - 20)
        Food6_plus.Location = New Point(280 * billy, 745 * billy - 20)
        Food6_name.Location = New Point(110 * billy, 450 * billy - 20)
        Food6_price.Location = New Point(240 * billy, 450 * billy - 20)

        Food6_pic.Size = New Size(240 * billy, 240 * billy)
        Food6_minus.Size = New Size(70 * billy, 70 * billy)
        Food6_amount.Size = New Size(80 * billy, 60 * billy)
        Food6_plus.Size = New Size(70 * billy, 70 * billy)
        Food6_name.Size = New Size(150 * billy, 50 * billy)
        Food6_price.Size = New Size(150 * billy, 50 * billy)

        Food7_pic.Location = New Point(475 * billy, 500 * billy - 20)
        Food7_minus.Location = New Point(475 * billy, 745 * billy - 20)
        Food7_amount.Location = New Point(555 * billy, 755 * billy - 20)
        Food7_plus.Location = New Point(645 * billy, 745 * billy - 20)
        Food7_name.Location = New Point(475 * billy, 450 * billy - 20)
        Food7_price.Location = New Point(605 * billy, 450 * billy - 20)

        Food7_pic.Size = New Size(240 * billy, 240 * billy)
        Food7_minus.Size = New Size(70 * billy, 70 * billy)
        Food7_amount.Size = New Size(80 * billy, 60 * billy)
        Food7_plus.Size = New Size(70 * billy, 70 * billy)
        Food7_name.Size = New Size(150 * billy, 50 * billy)
        Food7_price.Size = New Size(150 * billy, 50 * billy)

        Food8_pic.Location = New Point(840 * billy, 500 * billy - 20)
        Food8_minus.Location = New Point(840 * billy, 745 * billy - 20)
        Food8_amount.Location = New Point(920 * billy, 755 * billy - 20)
        Food8_plus.Location = New Point(1010 * billy, 745 * billy - 20)
        Food8_name.Location = New Point(840 * billy, 450 * billy - 20)
        Food8_price.Location = New Point(970 * billy, 450 * billy - 20)

        Food8_pic.Size = New Size(240 * billy, 240 * billy)
        Food8_minus.Size = New Size(70 * billy, 70 * billy)
        Food8_amount.Size = New Size(80 * billy, 60 * billy)
        Food8_plus.Size = New Size(70 * billy, 70 * billy)
        Food8_name.Size = New Size(150 * billy, 50 * billy)
        Food8_price.Size = New Size(150 * billy, 50 * billy)

        Food9_pic.Location = New Point(1205 * billy, 500 * billy - 20)
        Food9_minus.Location = New Point(1205 * billy, 745 * billy - 20)
        Food9_amount.Location = New Point(1285 * billy, 755 * billy - 20)
        Food9_plus.Location = New Point(1375 * billy, 745 * billy - 20)
        Food9_name.Location = New Point(1205 * billy, 450 * billy - 20)
        Food9_price.Location = New Point(1335 * billy, 450 * billy - 20)

        Food9_pic.Size = New Size(240 * billy, 240 * billy)
        Food9_minus.Size = New Size(70 * billy, 70 * billy)
        Food9_amount.Size = New Size(80 * billy, 60 * billy)
        Food9_plus.Size = New Size(70 * billy, 70 * billy)
        Food9_name.Size = New Size(150 * billy, 50 * billy)
        Food9_price.Size = New Size(150 * billy, 50 * billy)

        Food10_pic.Location = New Point(1570 * billy, 500 * billy - 20)
        Food10_minus.Location = New Point(1570 * billy, 745 * billy - 20)
        Food10_amount.Location = New Point(1650 * billy, 755 * billy - 20)
        Food10_plus.Location = New Point(1740 * billy, 745 * billy - 20)
        Food10_name.Location = New Point(1570 * billy, 450 * billy - 20)
        Food10_price.Location = New Point(1690 * billy, 450 * billy - 20)

        Food10_pic.Size = New Size(240 * billy, 240 * billy)
        Food10_minus.Size = New Size(70 * billy, 70 * billy)
        Food10_amount.Size = New Size(80 * billy, 60 * billy)
        Food10_plus.Size = New Size(70 * billy, 70 * billy)
        Food10_name.Size = New Size(150 * billy, 50 * billy)
        Food10_price.Size = New Size(150 * billy, 50 * billy)
#End Region

#Region "庫存管理介面"
        Inven_left.Location = New Point(10 * billy, 300 * billy)
        Inven_right.Location = New Point(1810 * billy, 300 * billy)
        Inven_pagesL.Location = New Point(450 * billy, 920 * billy)
        Inven_confirm_btn.Location = New Point(1400 * billy, 870 * billy)
        Inven_back_btn.Location = New Point(50 * billy, 50 * billy)
        Inven_add_btn.Location = New Point(1150 * billy, 870 * billy)
        Inven_warningL.Location = New Point(680 * billy, 100 * billy)

        Inven_left.Size = New Size(110 * billy, 260 * billy)
        Inven_right.Size = New Size(100 * billy, 260 * billy)
        Inven_confirm_btn.Size = New Size(180 * billy, 120 * billy)
        Inven_back_btn.Size = New Size(200 * billy, 120 * billy)
        Inven_add_btn.Size = New Size(180 * billy, 120 * billy)

        Inven_pagesL.Font = New Font(Inven_pagesL.Font.Name, CSng(40 * billy), FontStyle.Bold)
        Inven_confirm_btn.Font = New Font(Inven_confirm_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Inven_back_btn.Font = New Font(Inven_back_btn.Font.Name, CSng(48 * billy), FontStyle.Bold)
        Inven_add_btn.Font = New Font(Inven_add_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Inven_warningL.Font = New Font(Inven_warningL.Font.Name, CSng(22 * billy), FontStyle.Bold)


        Food1_pic_inven.Location = New Point(130 * billy, 200 * billy)
        Food1_nameL.Location = New Point(130 * billy, 465 * billy)
        Food1_invenL.Location = New Point(130 * billy, 500 * billy)
        Food1_lowinvenL.Location = New Point(130 * billy, 535 * billy)
        Food1_priceL.Location = New Point(130 * billy, 570 * billy)
        Food1_costL.Location = New Point(130 * billy, 605 * billy)
        Food1_onsaleL.Location = New Point(130 * billy, 640 * billy)
        Food1_numL.Location = New Point(130 * billy, 675 * billy)

        Food1_nameT.Location = New Point(230 * billy, 465 * billy)
        Food1_invenT.Location = New Point(230 * billy, 500 * billy)
        Food1_lowinvenT.Location = New Point(230 * billy, 535 * billy)
        Food1_priceT.Location = New Point(230 * billy, 570 * billy)
        Food1_costT.Location = New Point(230 * billy, 605 * billy)
        Food1_onsaleT.Location = New Point(230 * billy, 640 * billy)
        Food1_numT.Location = New Point(230 * billy, 675 * billy)
        Food1_delete_btn.Location = New Point(180 * billy, 710 * billy)

        Food1_pic_inven.Size = New Size(260 * billy, 260 * billy)
        Food1_nameT.Size = New Size(150 * billy, 22 * billy)
        Food1_invenT.Size = New Size(150 * billy, 22 * billy)
        Food1_lowinvenT.Size = New Size(150 * billy, 22 * billy)
        Food1_priceT.Size = New Size(150 * billy, 22 * billy)
        Food1_costT.Size = New Size(150 * billy, 22 * billy)
        Food1_onsaleT.Size = New Size(150 * billy, 22 * billy)
        Food1_numT.Size = New Size(150 * billy, 22 * billy)
        Food1_delete_btn.Size = New Size(150 * billy, 70 * billy)

        Food2_pic_inven.Location = New Point(600 * billy, 200 * billy)
        Food2_nameL.Location = New Point(600 * billy, 465 * billy)
        Food2_invenL.Location = New Point(600 * billy, 500 * billy)
        Food2_lowinvenL.Location = New Point(600 * billy, 535 * billy)
        Food2_priceL.Location = New Point(600 * billy, 570 * billy)
        Food2_costL.Location = New Point(600 * billy, 605 * billy)
        Food2_onsaleL.Location = New Point(600 * billy, 640 * billy)
        Food2_numL.Location = New Point(600 * billy, 675 * billy)

        Food2_nameT.Location = New Point(700 * billy, 465 * billy)
        Food2_invenT.Location = New Point(700 * billy, 500 * billy)
        Food2_lowinvenT.Location = New Point(700 * billy, 535 * billy)
        Food2_priceT.Location = New Point(700 * billy, 570 * billy)
        Food2_costT.Location = New Point(700 * billy, 605 * billy)
        Food2_onsaleT.Location = New Point(700 * billy, 640 * billy)
        Food2_numT.Location = New Point(700 * billy, 675 * billy)
        Food2_delete_btn.Location = New Point(650 * billy, 710 * billy)

        Food2_pic_inven.Size = New Size(260 * billy, 260 * billy)
        Food2_nameT.Size = New Size(150 * billy, 22 * billy)
        Food2_invenT.Size = New Size(150 * billy, 22 * billy)
        Food2_lowinvenT.Size = New Size(150 * billy, 22 * billy)
        Food2_priceT.Size = New Size(150 * billy, 22 * billy)
        Food2_costT.Size = New Size(150 * billy, 22 * billy)
        Food2_onsaleT.Size = New Size(150 * billy, 22 * billy)
        Food2_numT.Size = New Size(150 * billy, 22 * billy)
        Food2_delete_btn.Size = New Size(150 * billy, 70 * billy)

        Food3_pic_inven.Location = New Point(1070 * billy, 200 * billy)
        Food3_nameL.Location = New Point(1070 * billy, 465 * billy)
        Food3_invenL.Location = New Point(1070 * billy, 500 * billy)
        Food3_lowinvenL.Location = New Point(1070 * billy, 535 * billy)
        Food3_priceL.Location = New Point(1070 * billy, 570 * billy)
        Food3_costL.Location = New Point(1070 * billy, 605 * billy)
        Food3_onsaleL.Location = New Point(1070 * billy, 640 * billy)
        Food3_numL.Location = New Point(1070 * billy, 675 * billy)

        Food3_nameT.Location = New Point(1170 * billy, 465 * billy)
        Food3_invenT.Location = New Point(1170 * billy, 500 * billy)
        Food3_lowinvenT.Location = New Point(1170 * billy, 535 * billy)
        Food3_priceT.Location = New Point(1170 * billy, 570 * billy)
        Food3_costT.Location = New Point(1170 * billy, 605 * billy)
        Food3_onsaleT.Location = New Point(1170 * billy, 640 * billy)
        Food3_numT.Location = New Point(1170 * billy, 675 * billy)
        Food3_delete_btn.Location = New Point(1120 * billy, 710 * billy)

        Food3_pic_inven.Size = New Size(260 * billy, 260 * billy)
        Food3_nameT.Size = New Size(150 * billy, 22 * billy)
        Food3_invenT.Size = New Size(150 * billy, 22 * billy)
        Food3_lowinvenT.Size = New Size(150 * billy, 22 * billy)
        Food3_priceT.Size = New Size(150 * billy, 22 * billy)
        Food3_costT.Size = New Size(150 * billy, 22 * billy)
        Food3_onsaleT.Size = New Size(150 * billy, 22 * billy)
        Food3_numT.Size = New Size(150 * billy, 22 * billy)
        Food3_delete_btn.Size = New Size(150 * billy, 70 * billy)

        Food4_pic_inven.Location = New Point(1540 * billy, 200 * billy)
        Food4_nameL.Location = New Point(1540 * billy, 465 * billy)
        Food4_invenL.Location = New Point(1540 * billy, 500 * billy)
        Food4_lowinvenL.Location = New Point(1540 * billy, 535 * billy)
        Food4_priceL.Location = New Point(1540 * billy, 570 * billy)
        Food4_costL.Location = New Point(1540 * billy, 605 * billy)
        Food4_onsaleL.Location = New Point(1540 * billy, 640 * billy)
        Food4_numL.Location = New Point(1540 * billy, 675 * billy)

        Food4_nameT.Location = New Point(1640 * billy, 465 * billy)
        Food4_invenT.Location = New Point(1640 * billy, 500 * billy)
        Food4_lowinvenT.Location = New Point(1640 * billy, 535 * billy)
        Food4_priceT.Location = New Point(1640 * billy, 570 * billy)
        Food4_costT.Location = New Point(1640 * billy, 605 * billy)
        Food4_onsaleT.Location = New Point(1640 * billy, 640 * billy)
        Food4_numT.Location = New Point(1640 * billy, 675 * billy)
        Food4_delete_btn.Location = New Point(1590 * billy, 710 * billy)

        Food4_pic_inven.Size = New Size(260 * billy, 260 * billy)
        Food4_nameT.Size = New Size(150 * billy, 22 * billy)
        Food4_invenT.Size = New Size(150 * billy, 22 * billy)
        Food4_lowinvenT.Size = New Size(150 * billy, 22 * billy)
        Food4_priceT.Size = New Size(150 * billy, 22 * billy)
        Food4_costT.Size = New Size(150 * billy, 22 * billy)
        Food4_onsaleT.Size = New Size(150 * billy, 22 * billy)
        Food4_numT.Size = New Size(150 * billy, 22 * billy)
        Food4_delete_btn.Size = New Size(150 * billy, 70 * billy)

        Food1_nameL.Font = New Font(Food1_nameL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_invenL.Font = New Font(Food1_invenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_lowinvenL.Font = New Font(Food1_lowinvenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_priceL.Font = New Font(Food1_priceL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_costL.Font = New Font(Food1_costL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_onsaleL.Font = New Font(Food1_onsaleL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_numL.Font = New Font(Food1_numL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Food1_nameT.Font = New Font(Food1_nameT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_invenT.Font = New Font(Food1_invenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_lowinvenT.Font = New Font(Food1_lowinvenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_priceT.Font = New Font(Food1_priceT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_costT.Font = New Font(Food1_costT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_onsaleT.Font = New Font(Food1_onsaleT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_numT.Font = New Font(Food1_numT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food1_delete_btn.Font = New Font(Food1_delete_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)

        Food2_nameL.Font = New Font(Food2_nameL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_invenL.Font = New Font(Food2_invenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_lowinvenL.Font = New Font(Food2_lowinvenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_priceL.Font = New Font(Food2_priceL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_costL.Font = New Font(Food2_costL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_onsaleL.Font = New Font(Food2_onsaleL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_numL.Font = New Font(Food2_numL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Food2_nameT.Font = New Font(Food2_nameT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_invenT.Font = New Font(Food2_invenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_lowinvenT.Font = New Font(Food2_lowinvenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_priceT.Font = New Font(Food2_priceT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_costT.Font = New Font(Food2_costT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_onsaleT.Font = New Font(Food2_onsaleT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_numT.Font = New Font(Food2_numT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food2_delete_btn.Font = New Font(Food2_delete_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)

        Food3_nameL.Font = New Font(Food3_nameL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_invenL.Font = New Font(Food3_invenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_lowinvenL.Font = New Font(Food3_lowinvenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_priceL.Font = New Font(Food3_priceL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_costL.Font = New Font(Food3_costL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_onsaleL.Font = New Font(Food3_onsaleL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_numL.Font = New Font(Food3_numL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Food3_nameT.Font = New Font(Food3_nameT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_invenT.Font = New Font(Food3_invenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_lowinvenT.Font = New Font(Food3_lowinvenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_priceT.Font = New Font(Food3_priceT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_costT.Font = New Font(Food3_costT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_onsaleT.Font = New Font(Food3_onsaleT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_numT.Font = New Font(Food3_numT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food3_delete_btn.Font = New Font(Food3_delete_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)

        Food4_nameL.Font = New Font(Food4_nameL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_invenL.Font = New Font(Food4_invenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_lowinvenL.Font = New Font(Food4_lowinvenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_priceL.Font = New Font(Food4_priceL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_costL.Font = New Font(Food4_costL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_onsaleL.Font = New Font(Food4_onsaleL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_numL.Font = New Font(Food4_numL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Food4_nameT.Font = New Font(Food4_nameT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_invenT.Font = New Font(Food4_invenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_lowinvenT.Font = New Font(Food4_lowinvenT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_priceT.Font = New Font(Food4_priceT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_costT.Font = New Font(Food4_costT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_onsaleT.Font = New Font(Food4_onsaleT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_numT.Font = New Font(Food4_numT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Food4_delete_btn.Font = New Font(Food4_delete_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
#End Region

#Region "庫存新增介面"
        InvenAdd_confirm_btn.Location = New Point(970 * billy, 750 * billy)
        InvenAdd_cancel_btn.Location = New Point(770 * billy, 750 * billy)

        InvenAdd_confirm_btn.Size = New Size(180 * billy, 70 * billy)
        InvenAdd_cancel_btn.Size = New Size(180 * billy, 70 * billy)

        InvenAdd_confirm_btn.Font = New Font(InvenAdd_confirm_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        InvenAdd_cancel_btn.Font = New Font(InvenAdd_cancel_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)


        InvenAdd_pic.Location = New Point(830 * billy, 200 * billy)
        InvenAdd_nameL.Location = New Point(830 * billy, 465 * billy)
        InvenAdd_invenL.Location = New Point(830 * billy, 500 * billy)
        InvenAdd_lowinvenL.Location = New Point(830 * billy, 535 * billy)
        InvenAdd_priceL.Location = New Point(830 * billy, 570 * billy)
        InvenAdd_costL.Location = New Point(830 * billy, 605 * billy)
        InvenAdd_onsaleL.Location = New Point(830 * billy, 640 * billy)
        InvenAdd_numL.Location = New Point(830 * billy, 675 * billy)

        InvenAdd_nameT.Location = New Point(930 * billy, 465 * billy)
        InvenAdd_invenT.Location = New Point(930 * billy, 500 * billy)
        InvenAdd_lowinvenT.Location = New Point(930 * billy, 535 * billy)
        InvenAdd_priceT.Location = New Point(930 * billy, 570 * billy)
        InvenAdd_costT.Location = New Point(930 * billy, 605 * billy)
        InvenAdd_onsaleT.Location = New Point(930 * billy, 640 * billy)
        InvenAdd_numT.Location = New Point(930 * billy, 675 * billy)

        InvenAdd_pic.Size = New Size(260 * billy, 260 * billy)
        InvenAdd_nameT.Size = New Size(150 * billy, 22 * billy)
        InvenAdd_invenT.Size = New Size(150 * billy, 22 * billy)
        InvenAdd_lowinvenT.Size = New Size(150 * billy, 22 * billy)
        InvenAdd_priceT.Size = New Size(150 * billy, 22 * billy)
        InvenAdd_costT.Size = New Size(150 * billy, 22 * billy)
        InvenAdd_onsaleT.Size = New Size(150 * billy, 22 * billy)
        InvenAdd_numT.Size = New Size(150 * billy, 22 * billy)

        InvenAdd_nameL.Font = New Font(InvenAdd_nameL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        InvenAdd_invenL.Font = New Font(InvenAdd_invenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        InvenAdd_lowinvenL.Font = New Font(InvenAdd_lowinvenL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        InvenAdd_priceL.Font = New Font(InvenAdd_priceL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        InvenAdd_costL.Font = New Font(InvenAdd_costL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        InvenAdd_onsaleL.Font = New Font(InvenAdd_onsaleL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        InvenAdd_numL.Font = New Font(InvenAdd_numL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        InvenAdd_nameT.Font = New Font(InvenAdd_nameT.Font.Name, CSng(12 * billy), FontStyle.Regular)
        InvenAdd_invenT.Font = New Font(InvenAdd_invenT.Font.Name, CSng(12 * billy), FontStyle.Regular)
        InvenAdd_lowinvenT.Font = New Font(InvenAdd_lowinvenT.Font.Name, CSng(12 * billy), FontStyle.Regular)
        InvenAdd_priceT.Font = New Font(InvenAdd_priceT.Font.Name, CSng(12 * billy), FontStyle.Regular)
        InvenAdd_costT.Font = New Font(InvenAdd_costT.Font.Name, CSng(12 * billy), FontStyle.Regular)
        InvenAdd_onsaleT.Font = New Font(InvenAdd_onsaleT.Font.Name, CSng(12 * billy), FontStyle.Regular)
        InvenAdd_numT.Font = New Font(InvenAdd_numT.Font.Name, CSng(12 * billy), FontStyle.Regular)
#End Region

#Region "員工登入介面"
        Login_title.Location = New Point(700 * billy, 100 * billy)
        Login_sign_btn.Location = New Point(820 * billy, 450 * billy)
        Login_login_btn.Location = New Point(1020 * billy, 450 * billy)
        Login_back_btn.Location = New Point(50 * billy, 50 * billy)
        Login_errorL.Location = New Point(930 * billy, 380 * billy)

        Login_sign_btn.Size = New Size(150 * billy, 80 * billy)
        Login_login_btn.Size = New Size(150 * billy, 80 * billy)
        Login_back_btn.Size = New Size(200 * billy, 120 * billy)

        Login_title.Font = New Font(Login_title.Font.Name, CSng(100 * billy), FontStyle.Bold)
        Login_sign_btn.Font = New Font(Login_sign_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Login_login_btn.Font = New Font(Login_login_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Login_back_btn.Font = New Font(Login_back_btn.Font.Name, CSng(48 * billy), FontStyle.Bold)
        Login_errorL.Font = New Font(Login_errorL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Login_accL.Location = New Point(870 * billy, 300 * billy)
        Login_passL.Location = New Point(870 * billy, 350 * billy)

        Login_accT.Location = New Point(930 * billy, 300 * billy)
        Login_passT.Location = New Point(930 * billy, 350 * billy)

        Login_accT.Size = New Size(150 * billy, 22 * billy)
        Login_passT.Size = New Size(150 * billy, 22 * billy)

        Login_accL.Font = New Font(Login_accL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Login_passL.Font = New Font(Login_passL.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Login_accT.Font = New Font(Login_accT.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Login_passT.Font = New Font(Login_passT.Font.Name, CSng(12 * billy), FontStyle.Bold)
#End Region

#Region "訂單確認介面"
        Odconfirm_mealsL1.Location = New Point(780 * billy, 100 * billy)
        Odconfirm_spicyL.Location = New Point(780 * billy, 550 * billy)
        Odconfirm_noteL.Location = New Point(780 * billy, 600 * billy)
        Odconfirm_priceL.Location = New Point(780 * billy, 860 * billy)
        Odconfirm_mealsL2.Location = New Point(860 * billy, 105 * billy)
        Spicy_group.Location = New Point(860 * billy, 535 * billy)
        Odconfirm_noteT.Location = New Point(860 * billy, 605 * billy)

        Spicy_group.Size = New Size(300 * billy, 60 * billy)
        Odconfirm_noteT.Size = New Size(200 * billy, 230 * billy)

        Odconfirm_cancel_btn.Location = New Point(760 * billy, 900 * billy)
        Odconfirm_confirm_btn.Location = New Point(960 * billy, 900 * billy)

        Odconfirm_cancel_btn.Size = New Size(190 * billy, 80 * billy)
        Odconfirm_confirm_btn.Size = New Size(190 * billy, 80 * billy)

        Odconfirm_mealsL1.Font = New Font(Odconfirm_mealsL1.Font.Name, CSng(20 * billy), FontStyle.Bold)
        Odconfirm_spicyL.Font = New Font(Odconfirm_spicyL.Font.Name, CSng(20 * billy), FontStyle.Bold)
        Odconfirm_noteL.Font = New Font(Odconfirm_noteL.Font.Name, CSng(20 * billy), FontStyle.Bold)
        Odconfirm_priceL.Font = New Font(Odconfirm_priceL.Font.Name, CSng(20 * billy), FontStyle.Bold)
        Odconfirm_mealsL2.Font = New Font(Odconfirm_mealsL2.Font.Name, CSng(16 * billy), FontStyle.Bold)
        Odconfirm_noteT.Font = New Font(Odconfirm_noteT.Font.Name, CSng(10 * billy), FontStyle.Regular)
        RadioButton1.Font = New Font(RadioButton1.Font.Name, CSng(12 * billy), FontStyle.Bold)
        RadioButton2.Font = New Font(RadioButton2.Font.Name, CSng(12 * billy), FontStyle.Bold)
        RadioButton3.Font = New Font(RadioButton3.Font.Name, CSng(12 * billy), FontStyle.Bold)
        RadioButton4.Font = New Font(RadioButton4.Font.Name, CSng(12 * billy), FontStyle.Bold)

        Odconfirm_cancel_btn.Font = New Font(Odconfirm_cancel_btn.Font.Name, CSng(28 * billy), FontStyle.Regular)
        Odconfirm_confirm_btn.Font = New Font(Odconfirm_confirm_btn.Font.Name, CSng(28 * billy), FontStyle.Regular)

#End Region

#Region "員工功能介面"
        Emp_titleL.Location = New Point(670 * billy, 30 * billy)
        Emp_odsearch_btn.Location = New Point(820 * billy, 250 * billy)
        Emp_inventory_btn.Location = New Point(820 * billy, 400 * billy)
        Emp_report_btn.Location = New Point(820 * billy, 550 * billy)
        Emp_pass_btn.Location = New Point(820 * billy, 700 * billy)
        Emp_back_btn.Location = New Point(820 * billy, 850 * billy)

        Emp_odsearch_btn.Size = New Size(300 * billy, 100 * billy)
        Emp_inventory_btn.Size = New Size(300 * billy, 100 * billy)
        Emp_report_btn.Size = New Size(300 * billy, 100 * billy)
        Emp_pass_btn.Size = New Size(300 * billy, 100 * billy)
        Emp_back_btn.Size = New Size(300 * billy, 100 * billy)

        Emp_titleL.Font = New Font(Emp_titleL.Font.Name, CSng(100 * billy), FontStyle.Bold)
        Emp_odsearch_btn.Font = New Font(Emp_odsearch_btn.Font.Name, CSng(44 * billy), FontStyle.Bold)
        Emp_inventory_btn.Font = New Font(Emp_inventory_btn.Font.Name, CSng(44 * billy), FontStyle.Bold)
        Emp_report_btn.Font = New Font(Emp_report_btn.Font.Name, CSng(44 * billy), FontStyle.Bold)
        Emp_pass_btn.Font = New Font(Emp_pass_btn.Font.Name, CSng(44 * billy), FontStyle.Bold)
        Emp_back_btn.Font = New Font(Emp_back_btn.Font.Name, CSng(44 * billy), FontStyle.Bold)
#End Region

#Region "訂單查詢介面"
        Odsearch_Title.Location = New Point(670 * billy, 30 * billy)
        Odsearch_back_btn.Location = New Point(50 * billy, 50 * billy)
        Odsearch_day_btn.Location = New Point(380 * billy, 250 * billy)
        Odsearch_dayT.Location = New Point(380 * billy, 320 * billy)
        Odsearch_dayL.Location = New Point(380 * billy, 400 * billy)
        Odsearch_id_btn.Location = New Point(1100 * billy, 250 * billy)
        Odsearch_idT.Location = New Point(1100 * billy, 320 * billy)
        Odsearch_idL.Location = New Point(1100 * billy, 400 * billy)
        Odsearch_delete_btn.Location = New Point(1450 * billy, 250 * billy)

        Odsearch_back_btn.Size = New Size(200 * billy, 120 * billy)
        Odsearch_day_btn.Size = New Size(330 * billy, 60 * billy)
        Odsearch_id_btn.Size = New Size(330 * billy, 60 * billy)
        Odsearch_dayT.Size = New Size(150 * billy, 320 * billy)
        Odsearch_idT.Size = New Size(150 * billy, 320 * billy)
        Odsearch_delete_btn.Size = New Size(330 * billy, 60 * billy)

        Odsearch_Title.Font = New Font(Odsearch_Title.Font.Name, CSng(100 * billy), FontStyle.Bold)
        Odsearch_back_btn.Font = New Font(Odsearch_back_btn.Font.Name, CSng(48 * billy), FontStyle.Bold)
        Odsearch_day_btn.Font = New Font(Odsearch_day_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Odsearch_dayT.Font = New Font(Odsearch_dayT.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Odsearch_dayL.Font = New Font(Odsearch_dayL.Font.Name, CSng(16 * billy), FontStyle.Bold)
        Odsearch_id_btn.Font = New Font(Odsearch_id_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Odsearch_idT.Font = New Font(Odsearch_idT.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Odsearch_idL.Font = New Font(Odsearch_idL.Font.Name, CSng(16 * billy), FontStyle.Bold)
        Odsearch_delete_btn.Font = New Font(Odsearch_delete_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
#End Region

#Region "密碼修改介面"
        Pass_title.Location = New Point(680 * billy, 100 * billy)
        Pass_confirm_btn.Location = New Point(870 * billy, 400 * billy)
        Pass_cancel_btn.Location = New Point(870 * billy, 490 * billy)
        Pass_passL1.Location = New Point(850 * billy, 300 * billy)
        Pass_passL2.Location = New Point(850 * billy, 350 * billy)


        Pass_passT1.Location = New Point(930 * billy, 300 * billy)
        Pass_passT2.Location = New Point(930 * billy, 350 * billy)

        Pass_passT1.Size = New Size(150 * billy, 22 * billy)
        Pass_passT2.Size = New Size(150 * billy, 22 * billy)
        Pass_confirm_btn.Size = New Size(200 * billy, 70 * billy)
        Pass_cancel_btn.Size = New Size(200 * billy, 70 * billy)

        Pass_title.Font = New Font(Pass_title.Font.Name, CSng(100 * billy), FontStyle.Bold)
        Pass_confirm_btn.Font = New Font(Pass_confirm_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Pass_cancel_btn.Font = New Font(Pass_cancel_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Pass_passL1.Font = New Font(Pass_passL1.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Pass_passL2.Font = New Font(Pass_passL2.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Pass_passT1.Font = New Font(Pass_passT1.Font.Name, CSng(10 * billy), FontStyle.Bold)
        Pass_passT2.Font = New Font(Pass_passT2.Font.Name, CSng(10 * billy), FontStyle.Bold)
#End Region

#Region "營業報表介面"
        Report_titleL.Location = New Point(700 * billy, 100 * billy)
        Report_today_btn.Location = New Point(500 * billy, 260 * billy)
        Report_week_btn.Location = New Point(650 * billy, 260 * billy)
        Report_month_btn.Location = New Point(800 * billy, 260 * billy)
        Report_season_btn.Location = New Point(950 * billy, 260 * billy)
        Report_confirm_btn.Location = New Point(1110 * billy, 260 * billy)
        Report_startL.Location = New Point(1360 * billy, 260 * billy)
        Report_endL.Location = New Point(1360 * billy, 300 * billy)
        Report_start_date.Location = New Point(1440 * billy, 260 * billy)
        Report_end_date.Location = New Point(1440 * billy, 300 * billy)
        Report_dateL.Location = New Point(800 * billy, 330 * billy)
        Report_mealsL.Location = New Point(900 * billy, 360 * billy)
        Report_moneyL.Location = New Point(660 * billy, 800 * billy)
        Report_back_btn.Location = New Point(50 * billy, 50 * billy)


        Report_titleL.Size = New Size(650 * billy, 170 * billy)
        Report_today_btn.Size = New Size(120 * billy, 60 * billy)
        Report_week_btn.Size = New Size(120 * billy, 60 * billy)
        Report_month_btn.Size = New Size(120 * billy, 60 * billy)
        Report_season_btn.Size = New Size(120 * billy, 60 * billy)
        Report_confirm_btn.Size = New Size(240 * billy, 60 * billy)
        Report_back_btn.Size = New Size(200 * billy, 120 * billy)


        Report_titleL.Font = New Font(Report_titleL.Font.Name, CSng(100 * billy), FontStyle.Bold)
        Report_today_btn.Font = New Font(Report_today_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Report_week_btn.Font = New Font(Report_week_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Report_month_btn.Font = New Font(Report_month_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Report_season_btn.Font = New Font(Report_season_btn.Font.Name, CSng(28 * billy), FontStyle.Bold)
        Report_confirm_btn.Font = New Font(Report_confirm_btn.Font.Name, CSng(22 * billy), FontStyle.Bold)
        Report_startL.Font = New Font(Report_startL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Report_endL.Font = New Font(Report_endL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Report_dateL.Font = New Font(Report_dateL.Font.Name, CSng(12 * billy), FontStyle.Bold)
        Report_mealsL.Font = New Font(Report_mealsL.Font.Name, CSng(16 * billy), FontStyle.Bold)
        Report_moneyL.Font = New Font(Report_moneyL.Font.Name, CSng(24 * billy), FontStyle.Bold)
        Report_back_btn.Font = New Font(Report_back_btn.Font.Name, CSng(48 * billy), FontStyle.Bold)
#End Region


        ' Main_interface(False)
        Order_interface(False)
        Inventory_interface(False)
        InvenAdd_interface(False)
        Login_interface(False)
        Odconfirm_interface(False)
        Emp_interface(False)
        Odsearch_interface(False)
        Pass_interface(False)
        Report_interface(False)
    End Sub

    Public Sub Main_interface(b1 As Boolean)
        Order_btn.Visible = b1
        Setting_btn.Visible = b1
        Main_pic.Visible = b1
    End Sub

    Public Sub Order_interface(b1 As Boolean, Optional i1 As Integer = -1)
        Food1_amount.Text = "0"
        Food2_amount.Text = "0"
        Food3_amount.Text = "0"
        Food4_amount.Text = "0"
        Food5_amount.Text = "0"
        Food6_amount.Text = "0"
        Food7_amount.Text = "0"
        Food8_amount.Text = "0"
        Food9_amount.Text = "0"
        Food10_amount.Text = "0"





        If b1 = True Then
            cmd = "Select inventory FROM meals WHERE onsale=""no"" ORDER BY meals_id; "
            adpt = New MySqlDataAdapter(cmd, Conn)
            adpt.Fill(ds, "amount_limit")
        End If


        Order_left.Visible = b1
        Order_right.Visible = b1
        Order_pagesL.Visible = b1
        Order_confirm_btn.Visible = b1
        Order_back_btn.Visible = b1


        If i1 > 0 Or b1 = False Then
            Food1_pic.Visible = b1
            Food1_minus.Visible = b1
            Food1_amount.Visible = b1
            Food1_plus.Visible = b1
            Food1_name.Visible = b1
            Food1_price.Visible = b1
        End If

        If i1 > 1 Or b1 = False Then
            Food2_pic.Visible = b1
            Food2_minus.Visible = b1
            Food2_amount.Visible = b1
            Food2_plus.Visible = b1
            Food2_name.Visible = b1
            Food2_price.Visible = b1
        End If

        If i1 > 2 Or b1 = False Then
            Food3_pic.Visible = b1
            Food3_minus.Visible = b1
            Food3_amount.Visible = b1
            Food3_plus.Visible = b1
            Food3_name.Visible = b1
            Food3_price.Visible = b1
        End If

        If i1 > 3 Or b1 = False Then
            Food4_pic.Visible = b1
            Food4_minus.Visible = b1
            Food4_amount.Visible = b1
            Food4_plus.Visible = b1
            Food4_name.Visible = b1
            Food4_price.Visible = b1
        End If

        If i1 > 4 Or b1 = False Then
            Food5_pic.Visible = b1
            Food5_minus.Visible = b1
            Food5_amount.Visible = b1
            Food5_plus.Visible = b1
            Food5_name.Visible = b1
            Food5_price.Visible = b1
        End If

        If i1 > 5 Or b1 = False Then
            Food6_pic.Visible = b1
            Food6_minus.Visible = b1
            Food6_amount.Visible = b1
            Food6_plus.Visible = b1
            Food6_name.Visible = b1
            Food6_price.Visible = b1
        End If

        If i1 > 6 Or b1 = False Then
            Food7_pic.Visible = b1
            Food7_minus.Visible = b1
            Food7_amount.Visible = b1
            Food7_plus.Visible = b1
            Food7_name.Visible = b1
            Food7_price.Visible = b1
        End If

        If i1 > 7 Or b1 = False Then
            Food8_pic.Visible = b1
            Food8_minus.Visible = b1
            Food8_amount.Visible = b1
            Food8_plus.Visible = b1
            Food8_name.Visible = b1
            Food8_price.Visible = b1
        End If

        If i1 > 8 Or b1 = False Then
            Food9_pic.Visible = b1
            Food9_minus.Visible = b1
            Food9_amount.Visible = b1
            Food9_plus.Visible = b1
            Food9_name.Visible = b1
            Food9_price.Visible = b1
        End If

        If i1 > 9 Or b1 = False Then
            Food10_pic.Visible = b1
            Food10_minus.Visible = b1
            Food10_amount.Visible = b1
            Food10_plus.Visible = b1
            Food10_name.Visible = b1
            Food10_price.Visible = b1
        End If

    End Sub

    Public Sub Inventory_interface(b1 As Boolean, Optional i1 As Integer = -1)
        Inven_left.Visible = b1
        Inven_right.Visible = b1
        Inven_pagesL.Visible = b1
        Inven_confirm_btn.Visible = b1
        Inven_back_btn.Visible = b1
        Inven_add_btn.Visible = b1
        Inven_warningL.Visible = b1

        Food1_nameT.Text = ""
        Food1_invenT.Text = ""
        Food1_lowinvenT.Text = ""
        Food1_priceT.Text = ""
        Food1_costT.Text = ""
        Food1_onsaleT.Text = ""
        Food1_numT.Text = ""

        Food2_nameT.Text = ""
        Food2_invenT.Text = ""
        Food2_lowinvenT.Text = ""
        Food2_priceT.Text = ""
        Food2_costT.Text = ""
        Food2_onsaleT.Text = ""
        Food2_numT.Text = ""

        Food3_nameT.Text = ""
        Food3_invenT.Text = ""
        Food3_lowinvenT.Text = ""
        Food3_priceT.Text = ""
        Food3_costT.Text = ""
        Food3_onsaleT.Text = ""
        Food3_numT.Text = ""

        Food4_nameT.Text = ""
        Food4_invenT.Text = ""
        Food4_lowinvenT.Text = ""
        Food4_priceT.Text = ""
        Food4_costT.Text = ""
        Food4_onsaleT.Text = ""
        Food4_numT.Text = ""

        If i1 > 0 Or b1 = False Then
            Food1_pic_inven.Visible = b1
            Food1_nameL.Visible = b1
            Food1_invenL.Visible = b1
            Food1_lowinvenL.Visible = b1
            Food1_priceL.Visible = b1
            Food1_costL.Visible = b1
            Food1_onsaleL.Visible = b1
            Food1_numL.Visible = b1

            Food1_nameT.Visible = b1
            Food1_invenT.Visible = b1
            Food1_lowinvenT.Visible = b1
            Food1_priceT.Visible = b1
            Food1_costT.Visible = b1
            Food1_onsaleT.Visible = b1
            Food1_numT.Visible = b1
            Food1_delete_btn.Visible = b1
        End If

        If i1 > 1 Or b1 = False Then
            Food2_pic_inven.Visible = b1
            Food2_nameL.Visible = b1
            Food2_invenL.Visible = b1
            Food2_lowinvenL.Visible = b1
            Food2_priceL.Visible = b1
            Food2_costL.Visible = b1
            Food2_onsaleL.Visible = b1
            Food2_numL.Visible = b1

            Food2_nameT.Visible = b1
            Food2_invenT.Visible = b1
            Food2_lowinvenT.Visible = b1
            Food2_priceT.Visible = b1
            Food2_costT.Visible = b1
            Food2_onsaleT.Visible = b1
            Food2_numT.Visible = b1
            Food2_delete_btn.Visible = b1
        End If


        If i1 > 2 Or b1 = False Then
            Food3_pic_inven.Visible = b1
            Food3_nameL.Visible = b1
            Food3_invenL.Visible = b1
            Food3_lowinvenL.Visible = b1
            Food3_priceL.Visible = b1
            Food3_costL.Visible = b1
            Food3_onsaleL.Visible = b1
            Food3_numL.Visible = b1

            Food3_nameT.Visible = b1
            Food3_invenT.Visible = b1
            Food3_lowinvenT.Visible = b1
            Food3_priceT.Visible = b1
            Food3_costT.Visible = b1
            Food3_onsaleT.Visible = b1
            Food3_numT.Visible = b1
            Food3_delete_btn.Visible = b1
        End If

        If i1 > 3 Or b1 = False Then
            Food4_pic_inven.Visible = b1
            Food4_nameL.Visible = b1
            Food4_invenL.Visible = b1
            Food4_lowinvenL.Visible = b1
            Food4_priceL.Visible = b1
            Food4_costL.Visible = b1
            Food4_onsaleL.Visible = b1
            Food4_numL.Visible = b1

            Food4_nameT.Visible = b1
            Food4_invenT.Visible = b1
            Food4_lowinvenT.Visible = b1
            Food4_priceT.Visible = b1
            Food4_costT.Visible = b1
            Food4_onsaleT.Visible = b1
            Food4_numT.Visible = b1
            Food4_delete_btn.Visible = b1
        End If


    End Sub

    Public Sub InvenAdd_interface(b1 As Boolean)
        InvenAdd_pic.Image = My.Resources.plus
        InvenAdd_nameT.Text = ""
        InvenAdd_invenT.Text = ""
        InvenAdd_lowinvenT.Text = ""
        InvenAdd_priceT.Text = ""
        InvenAdd_costT.Text = ""
        InvenAdd_onsaleT.Text = ""
        InvenAdd_numT.Text = ""

        InvenAdd_confirm_btn.Visible = b1
        InvenAdd_cancel_btn.Visible = b1

        InvenAdd_pic.Visible = b1
        InvenAdd_nameL.Visible = b1
        InvenAdd_invenL.Visible = b1
        InvenAdd_lowinvenL.Visible = b1
        InvenAdd_priceL.Visible = b1
        InvenAdd_costL.Visible = b1
        InvenAdd_onsaleL.Visible = b1
        InvenAdd_numL.Visible = b1

        InvenAdd_nameT.Visible = b1
        InvenAdd_invenT.Visible = b1
        InvenAdd_lowinvenT.Visible = b1
        InvenAdd_priceT.Visible = b1
        InvenAdd_costT.Visible = b1
        InvenAdd_onsaleT.Visible = b1
        InvenAdd_numT.Visible = b1
    End Sub

    Public Sub Login_interface(b1 As Boolean)
        Login_accT.Text = ""
        Login_passT.Text = ""
        Login_errorL.Text = ""

        Login_errorL.Visible = b1
        Login_title.Visible = b1
        Login_sign_btn.Visible = b1
        Login_login_btn.Visible = b1
        Login_back_btn.Visible = b1
        Login_accL.Visible = b1
        Login_passL.Visible = b1
        Login_accT.Visible = b1
        Login_passT.Visible = b1
    End Sub

    Public Sub Odconfirm_interface(b1 As Boolean)
        RadioButton1.Checked = True
        Odconfirm_noteT.Text = ""
        Odconfirm_priceL.Text = "總金額:" & totalmoney

        Odconfirm_mealsL1.Visible = b1
        Odconfirm_spicyL.Visible = b1
        Odconfirm_noteL.Visible = b1
        Odconfirm_priceL.Visible = b1

        Odconfirm_mealsL2.Visible = b1
        Spicy_group.Visible = b1
        Odconfirm_noteT.Visible = b1

        Odconfirm_cancel_btn.Visible = b1
        Odconfirm_confirm_btn.Visible = b1
    End Sub

    Public Sub Emp_interface(b1 As Boolean)
        Emp_titleL.Visible = b1
        Emp_odsearch_btn.Visible = b1
        Emp_inventory_btn.Visible = b1
        Emp_report_btn.Visible = b1
        Emp_pass_btn.Visible = b1
        Emp_back_btn.Visible = b1
    End Sub

    Public Sub Odsearch_interface(b1 As Boolean)
        Odsearch_dayT.Text = "1"
        Odsearch_idT.Text = ""
        Odsearch_dayL.Text = ""
        Odsearch_idL.Text = ""

        Odsearch_Title.Visible = b1
        Odsearch_back_btn.Visible = b1
        Odsearch_day_btn.Visible = b1
        Odsearch_dayT.Visible = b1
        Odsearch_dayL.Visible = b1
        Odsearch_id_btn.Visible = b1
        Odsearch_idT.Visible = b1
        Odsearch_idL.Visible = b1
        Odsearch_delete_btn.Visible = b1

    End Sub

    Public Sub Pass_interface(b1 As Boolean)
        Pass_title.Visible = b1
        Pass_confirm_btn.Visible = b1
        Pass_cancel_btn.Visible = b1
        Pass_passL1.Visible = b1
        Pass_passL2.Visible = b1

        Pass_passT1.Visible = b1
        Pass_passT2.Visible = b1
    End Sub

    Public Sub Report_interface(b1 As Boolean)
        Date_now = Date.Now
        Report_start_date.MaxDate = Date_now
        Report_end_date.MaxDate = Date_now
        Report_dateL.Text = ""
        Report_mealsL.Text = ""
        Report_moneyL.Text = ""

        Report_titleL.Visible = b1
        Report_today_btn.Visible = b1
        Report_week_btn.Visible = b1
        Report_month_btn.Visible = b1
        Report_season_btn.Visible = b1
        Report_confirm_btn.Visible = b1
        Report_startL.Visible = b1
        Report_endL.Visible = b1
        Report_start_date.Visible = b1
        Report_end_date.Visible = b1
        Report_dateL.Visible = b1
        Report_mealsL.Visible = b1
        Report_moneyL.Visible = b1
        Report_back_btn.Visible = b1
    End Sub

    '主介面
    Private Sub Setting_btn_Click(sender As Object, e As EventArgs) Handles Setting_btn.Click
        Main_interface(False)
        Login_interface(True)
    End Sub

    Private Sub Order_btn_Click(sender As Object, e As EventArgs) Handles Order_btn.Click
        Main_interface(False)

        Order_mealsupdate(pages)
    End Sub
    '主介面結束




    '點餐介面
#Region "點餐介面餐點數量加減"
    Private Sub Food1_plus_Click(sender As Object, e As EventArgs) Handles Food1_plus.Click
        If ds.Tables("amount_limit").Rows((pages - 1) * 10).Item("inventory") > Food1_amount.Text Then
            Food1_amount.Text += 1
        End If
    End Sub

    Private Sub Food1_minus_Click(sender As Object, e As EventArgs) Handles Food1_minus.Click
        If Food1_amount.Text > 0 Then
            Food1_amount.Text -= 1
        End If
    End Sub

    Private Sub Food2_plus_Click(sender As Object, e As EventArgs) Handles Food2_plus.Click
        If ds.Tables("amount_limit").Rows(1 + (pages - 1) * 10).Item("inventory") > Food2_amount.Text Then
            Food2_amount.Text += 1
        End If
    End Sub

    Private Sub Food2_minus_Click(sender As Object, e As EventArgs) Handles Food2_minus.Click
        If Food2_amount.Text > 0 Then
            Food2_amount.Text -= 1
        End If
    End Sub

    Private Sub Food3_plus_Click(sender As Object, e As EventArgs) Handles Food3_plus.Click
        If ds.Tables("amount_limit").Rows(2 + (pages - 1) * 10).Item("inventory") > Food3_amount.Text Then
            Food3_amount.Text += 1
        End If
    End Sub

    Private Sub Food3_minus_Click(sender As Object, e As EventArgs) Handles Food3_minus.Click
        If Food3_amount.Text > 0 Then
            Food3_amount.Text -= 1
        End If
    End Sub

    Private Sub Food4_plus_Click(sender As Object, e As EventArgs) Handles Food4_plus.Click
        If ds.Tables("amount_limit").Rows(3 + (pages - 1) * 10).Item("inventory") > Food4_amount.Text Then
            Food4_amount.Text += 1
        End If
    End Sub

    Private Sub Food4_minus_Click(sender As Object, e As EventArgs) Handles Food4_minus.Click
        If Food4_amount.Text > 0 Then
            Food4_amount.Text -= 1
        End If
    End Sub

    Private Sub Food5_plus_Click(sender As Object, e As EventArgs) Handles Food5_plus.Click
        If ds.Tables("amount_limit").Rows(4 + (pages - 1) * 10).Item("inventory") > Food5_amount.Text Then
            Food5_amount.Text += 1
        End If
    End Sub

    Private Sub Food5_minus_Click(sender As Object, e As EventArgs) Handles Food5_minus.Click
        If Food5_amount.Text > 0 Then
            Food5_amount.Text -= 1
        End If
    End Sub

    Private Sub Food6_plus_Click(sender As Object, e As EventArgs) Handles Food6_plus.Click
        If ds.Tables("amount_limit").Rows(5 + (pages - 1) * 10).Item("inventory") > Food6_amount.Text Then
            Food6_amount.Text += 1
        End If
    End Sub

    Private Sub Food6_minus_Click(sender As Object, e As EventArgs) Handles Food6_minus.Click
        If Food6_amount.Text > 0 Then
            Food6_amount.Text -= 1
        End If
    End Sub

    Private Sub Food7_plus_Click(sender As Object, e As EventArgs) Handles Food7_plus.Click
        If ds.Tables("amount_limit").Rows(6 + (pages - 1) * 10).Item("inventory") > Food7_amount.Text Then
            Food7_amount.Text += 1
        End If
    End Sub

    Private Sub Food7_minus_Click(sender As Object, e As EventArgs) Handles Food7_minus.Click
        If Food7_amount.Text > 0 Then
            Food7_amount.Text -= 1
        End If
    End Sub

    Private Sub Food8_plus_Click(sender As Object, e As EventArgs) Handles Food8_plus.Click
        If ds.Tables("amount_limit").Rows(7 + (pages - 1) * 10).Item("inventory") > Food8_amount.Text Then
            Food8_amount.Text += 1
        End If
    End Sub

    Private Sub Food8_minus_Click(sender As Object, e As EventArgs) Handles Food8_minus.Click
        If Food8_amount.Text > 0 Then
            Food8_amount.Text -= 1
        End If
    End Sub

    Private Sub Food9_plus_Click(sender As Object, e As EventArgs) Handles Food9_plus.Click
        If ds.Tables("amount_limit").Rows(8 + (pages - 1) * 10).Item("inventory") > Food9_amount.Text Then
            Food9_amount.Text += 1
        End If
    End Sub

    Private Sub Food9_minus_Click(sender As Object, e As EventArgs) Handles Food9_minus.Click
        If Food9_amount.Text > 0 Then
            Food9_amount.Text -= 1
        End If
    End Sub

    Private Sub Food10_plus_Click(sender As Object, e As EventArgs) Handles Food10_plus.Click
        If ds.Tables("amount_limit").Rows(9 + (pages - 1) * 10).Item("inventory") > Food10_amount.Text Then
            Food10_amount.Text += 1
        End If
    End Sub

    Private Sub Food10_minus_Click(sender As Object, e As EventArgs) Handles Food10_minus.Click
        If Food10_amount.Text > 0 Then
            Food10_amount.Text -= 1
        End If
    End Sub
#End Region
    Function Totalpages_order() As String
        cmd = "Select COUNT(*) FROM meals WHERE onsale=""no"" "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")
        Dim re As String = Math.Ceiling(ds.Tables("meals_amount").Rows(0).Item("COUNT(*)") / 10).ToString

        ds.Tables("meals_amount").Clear()

        Return "第 " & pages & " / " & re & " 頁"
    End Function


    Private Sub Order_mealsupdate(pgs As Integer)
        Order_interface(False)

        cmd = "Select COUNT(*) FROM meals WHERE onsale=""no"" ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")
        meals_amount = ds.Tables("meals_amount").Rows(0).Item("COUNT(*)")

        If meals_amount >= pgs * 10 Then
            actual_amount = 10
        Else
            actual_amount = meals_amount Mod 10
        End If

        Order_interface(True, actual_amount)
        Order_pagesL.Text = Totalpages_order()
        For i As Integer = 0 To actual_amount - 1
            Select Case i
                Case 0
                    Food1_amount.Text = meals_numbers((pgs - 1) * 10)
                Case 1
                    Food2_amount.Text = meals_numbers(1 + (pgs - 1) * 10)
                Case 2
                    Food3_amount.Text = meals_numbers(2 + (pgs - 1) * 10)
                Case 3
                    Food4_amount.Text = meals_numbers(3 + (pgs - 1) * 10)
                Case 4
                    Food5_amount.Text = meals_numbers(4 + (pgs - 1) * 10)
                Case 5
                    Food6_amount.Text = meals_numbers(5 + (pgs - 1) * 10)
                Case 6
                    Food7_amount.Text = meals_numbers(6 + (pgs - 1) * 10)
                Case 7
                    Food8_amount.Text = meals_numbers(7 + (pgs - 1) * 10)
                Case 8
                    Food9_amount.Text = meals_numbers(8 + (pgs - 1) * 10)
                Case 9
                    Food10_amount.Text = meals_numbers(9 + (pgs - 1) * 10)
            End Select
        Next

        cmd = "Select * FROM meals WHERE onsale=""no"" ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals")

        For i As Integer = 0 To actual_amount - 1
            lb = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("image")
            lstr = New System.IO.MemoryStream(lb)

            Select Case i
                Case 0
                    Food1_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food1_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food1_pic.Image = Image.FromStream(lstr)
                Case 1
                    Food2_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food2_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food2_pic.Image = Image.FromStream(lstr)
                Case 2
                    Food3_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food3_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food3_pic.Image = Image.FromStream(lstr)
                Case 3
                    Food4_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food4_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food4_pic.Image = Image.FromStream(lstr)
                Case 4
                    Food5_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food5_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food5_pic.Image = Image.FromStream(lstr)
                Case 5
                    Food6_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food6_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food6_pic.Image = Image.FromStream(lstr)
                Case 6
                    Food7_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food7_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food7_pic.Image = Image.FromStream(lstr)
                Case 7
                    Food8_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food8_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food8_pic.Image = Image.FromStream(lstr)
                Case 8
                    Food9_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food9_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food9_pic.Image = Image.FromStream(lstr)
                Case 9
                    Food10_name.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("name")
                    Food10_price.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 10).Item("price") & "元"
                    Food10_pic.Image = Image.FromStream(lstr)
            End Select
        Next


        ds.Tables("meals_amount").Clear()
        ds.Tables("meals").Clear()
    End Sub

    Private Sub Order_amountrecord(pgs As Integer)

        cmd = "Select COUNT(*) FROM meals WHERE onsale=""no"" "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")

        meals_amount = ds.Tables("meals_amount").Rows(0).Item("COUNT(*)")

        If meals_amount >= pgs * 10 Then
            actual_amount = 10
        Else
            actual_amount = meals_amount Mod 10
        End If

        For i As Integer = 0 To actual_amount - 1
            Select Case i
                Case 0
                    meals_numbers((pgs - 1) * 10) = CInt(Food1_amount.Text)
                Case 1
                    meals_numbers(1 + (pgs - 1) * 10) = CInt(Food2_amount.Text)
                Case 2
                    meals_numbers(2 + (pgs - 1) * 10) = CInt(Food3_amount.Text)
                Case 3
                    meals_numbers(3 + (pgs - 1) * 10) = CInt(Food4_amount.Text)
                Case 4
                    meals_numbers(4 + (pgs - 1) * 10) = CInt(Food5_amount.Text)
                Case 5
                    meals_numbers(5 + (pgs - 1) * 10) = CInt(Food6_amount.Text)
                Case 6
                    meals_numbers(6 + (pgs - 1) * 10) = CInt(Food7_amount.Text)
                Case 7
                    meals_numbers(7 + (pgs - 1) * 10) = CInt(Food8_amount.Text)
                Case 8
                    meals_numbers(8 + (pgs - 1) * 10) = CInt(Food9_amount.Text)
                Case 9
                    meals_numbers(9 + (pgs - 1) * 10) = CInt(Food10_amount.Text)
            End Select
        Next



        ds.Tables("meals_amount").Clear()
    End Sub

    Private Sub Order_right_Click(sender As Object, e As EventArgs) Handles Order_right.Click
        cmd = "Select COUNT(*) FROM meals WHERE onsale=""no"""
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")
        meals_amount = ds.Tables("meals_amount").Rows(0).Item("COUNT(*)")

        If pages * 10 < meals_amount Then
            Order_amountrecord(pages)
            pages += 1
            Order_mealsupdate(pages)
        End If
        ds.Tables("meals_amount").Clear()
    End Sub

    Private Sub Order_left_Click(sender As Object, e As EventArgs) Handles Order_left.Click
        If pages > 1 Then
            Order_amountrecord(pages)
            pages -= 1
            Order_mealsupdate(pages)
        End If
    End Sub

    Private Sub Order_confirm_btn_Click(sender As Object, e As EventArgs) Handles Order_confirm_btn.Click
        Order_amountrecord(pages)
        totalmoney = 0
        Odconfirm_mealsL2.Text = ""
        cmd = "SELECT * FROM meals WHERE onsale=""no"" ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals")

        For i As Integer = 0 To 499
            If meals_numbers(i) > 0 Then
                Odconfirm_mealsL2.Text &= ds.Tables("meals").Rows(i).Item("name") & ": " & meals_numbers(i) & "份" & vbNewLine
                totalmoney += meals_numbers(i) * CInt(ds.Tables("meals").Rows(i).Item("price"))
            End If
        Next

        ds.Tables("meals").Clear()

        Order_interface(False)
        Odconfirm_interface(True)
    End Sub

    Private Sub Order_back_btn_Click(sender As Object, e As EventArgs) Handles Order_back_btn.Click
        Order_interface(False)
        Main_interface(True)
        ds.Tables("amount_limit").Clear()
        pages = 1
        For i As Integer = 0 To 499
            meals_numbers(i) = 0
        Next
    End Sub
    '點餐介面結束





    '點餐確認介面
    Private Sub Odconfirm_confirm_btn_Click(sender As Object, e As EventArgs) Handles Odconfirm_confirm_btn.Click
        Date_now = DateAndTime.Now


        cmd = "SELECT * FROM meals WHERE onsale=""no"" ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals")

        cmd = "SELECT COUNT(*) FROM cus_order; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "order_amount")
        order_amount = ds.Tables("order_amount").Rows(0).Item("COUNT(*)")

        If RadioButton1.Checked = True Then
            spicy = "無"
        ElseIf RadioButton2.Checked = True Then
            spicy = "小"
        ElseIf RadioButton3.Checked = True Then
            spicy = "中"
        ElseIf RadioButton4.Checked = True Then
            spicy = "大"
        End If

        If totalmoney > 0 Then
            Conn.Open()
            ccmd = Conn.CreateCommand
            ccmd.CommandText = "INSERT INTO cus_order (od_id, totalmoney, spicy, generation_time, note)
                                       VALUES (@od_id, @totalmoney, @spicy, @generation_time, @note)"
            ccmd.Parameters.AddWithValue("@od_id", "od_" + (order_amount + 1).ToString)
            ccmd.Parameters.AddWithValue("@totalmoney", totalmoney)
            ccmd.Parameters.AddWithValue("@spicy", spicy)
            ccmd.Parameters.AddWithValue("@generation_time", Date_now)
            ccmd.Parameters.AddWithValue("@note", Odconfirm_noteT.Text)

            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()
            Conn.Close()

            For i As Integer = 0 To 499
                If meals_numbers(i) > 0 Then
                    Conn.Open()
                    ccmd = Conn.CreateCommand
                    ccmd.CommandText = "INSERT INTO meals_amount (order_id, meals_id, amount)
                                       VALUES (@order_id, @meals_id, @amount)"
                    ccmd.Parameters.AddWithValue("@order_id", "od_" + (order_amount + 1).ToString)
                    ccmd.Parameters.AddWithValue("@meals_id", ds.Tables("meals").Rows(i).Item("meals_id"))
                    ccmd.Parameters.AddWithValue("@amount", meals_numbers(i))

                    ccmd.ExecuteNonQuery()
                    ccmd.Parameters.Clear()


                    ccmd = Conn.CreateCommand
                    ccmd.CommandText = "UPDATE meals SET inventory=@inventory WHERE meals_id = @meals_id"

                    ccmd.Parameters.AddWithValue("@inventory", ds.Tables("meals").Rows(i).Item("inventory") - meals_numbers(i))
                    ccmd.Parameters.AddWithValue("@meals_id", ds.Tables("meals").Rows(i).Item("meals_id"))

                    ccmd.ExecuteNonQuery()
                    ccmd.Parameters.Clear()
                    Conn.Close()
                End If
            Next

            For i As Integer = 0 To 499
                meals_numbers(i) = 0
            Next
            pages = 1

            MsgBox("成功送出!" & vbNewLine & "訂單編號 : " & "od_" + (order_amount + 1).ToString & vbNewLine & "請至櫃台結帳", vbOKOnly, "成功")
            Odconfirm_interface(False)
            Main_interface(True)
        Else
            MsgBox("購物車內無餐點", vbOKOnly, "錯誤")
            Odconfirm_interface(False)
            Order_mealsupdate(pages)

        End If





        ds.Tables("amount_limit").Clear()
        ds.Tables("order_amount").Clear()
        ds.Tables("meals").Clear()
    End Sub

    Private Sub Odconfirm_cancel_btn_Click(sender As Object, e As EventArgs) Handles Odconfirm_cancel_btn.Click
        Odconfirm_interface(False)
        Order_mealsupdate(pages)
    End Sub
    '點餐確認介面結束





    '員工登入介面
    Private Sub Login_back_btn_Click(sender As Object, e As EventArgs) Handles Login_back_btn.Click

        Login_interface(False)
        Main_interface(True)
    End Sub

    Private Sub Login_login_btn_Click(sender As Object, e As EventArgs) Handles Login_login_btn.Click
        cmd = "SELECT password FROM clerk WHERE account=""" & Login_accT.Text & """"
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "password")
        Login_errorL.Text = ""
        Try
            If Login_passT.Text = ds.Tables("password").Rows(0).Item("password") Then
                Account = Login_accT.Text
                Login_interface(False)
                Emp_interface(True)
            Else
                Login_errorL.Text = "帳號或密碼錯誤"
            End If
        Catch ex As Exception
            Login_errorL.Text = "帳號或密碼錯誤"
        End Try

        ds.Tables("password").Clear()
    End Sub

    Private Sub Login_sign_btn_Click(sender As Object, e As EventArgs) Handles Login_sign_btn.Click
        cmd = "SELECT password FROM clerk WHERE account=""" & Login_accT.Text & """"
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "password")
        Login_errorL.Text = ""
        Try
            If Login_passT.Text = ds.Tables("password").Rows(0).Item("password") Then
                Randomize()
                Naccount = RndNum.Next(100000, 1000000).ToString

                If MsgBox("確定新建一個員工帳號:" & Naccount & vbNewLine & "密碼:1234", vbYesNo, "註冊帳號") = 6 Then
                    Conn.Open()
                    ccmd = Conn.CreateCommand
                    ccmd.CommandText = "INSERT INTO clerk (account, password) VALUES (@account, @password)"

                    ccmd.Parameters.AddWithValue("@account", Naccount)
                    ccmd.Parameters.AddWithValue("@password", "1234")

                    ccmd.ExecuteNonQuery()

                    ccmd.Parameters.Clear()
                    Conn.Close()
                    MsgBox("註冊成功" & vbNewLine & "帳號:" & Naccount & vbNewLine & "密碼:1234" & vbNewLine & "請盡速更改密碼", vbOKCancel, "註冊成功")
                    Account = Naccount
                    Login_interface(False)
                    Emp_interface(True)
                End If
            End If
        Catch ex As Exception
            Login_errorL.Text = "帳號或密碼錯誤"
        End Try

        ds.Tables("password").Clear()
    End Sub
    '員工登入介面結束





    '員工功能介面
    Private Sub Emp_odsearch_btn_Click(sender As Object, e As EventArgs) Handles Emp_odsearch_btn.Click
        Emp_interface(False)
        Odsearch_interface(True)
    End Sub

    Private Sub Emp_inventory_btn_Click(sender As Object, e As EventArgs) Handles Emp_inventory_btn.Click
        Emp_interface(False)
        Inventory_warning()
        Inventory_mealsupdate(pages)
    End Sub

    Private Sub Emp_report_btn_Click(sender As Object, e As EventArgs) Handles Emp_report_btn.Click
        Emp_interface(False)
        Report_interface(True)
    End Sub

    Private Sub Emp_pass_btn_Click(sender As Object, e As EventArgs) Handles Emp_pass_btn.Click
        Emp_interface(False)
        Pass_interface(True)
    End Sub

    Private Sub Emp_back_btn_Click(sender As Object, e As EventArgs) Handles Emp_back_btn.Click
        Emp_interface(False)
        Main_interface(True)
    End Sub
    '員工功能介面結束





    '訂單查詢介面
    Private Sub Odsearch_day_btn_Click(sender As Object, e As EventArgs) Handles Odsearch_day_btn.Click
        Odsearch_dayL.Text = ""
        date_now = DateAndTime.Now
        Dim Datepre As Date

        If CInt(Odsearch_dayT.Text) > 0 Then
            Try
                datepre = DateAdd("d", -1 * CInt(Odsearch_dayT.Text), date_now)
                cmd = "Select * FROM cus_order WHERE generation_time>=""" & Datepre & """ ORDER BY generation_time DESC"
                adpt = New MySqlDataAdapter(cmd, Conn)
                adpt.Fill(ds, "cus_order")

                cmd = "Select COUNT(*) FROM cus_order WHERE generation_time>=""" & datepre & """"
                adpt = New MySqlDataAdapter(cmd, Conn)
                adpt.Fill(ds, "cus_order_amount")

                If ds.Tables("cus_order_amount").Rows(0).Item("COUNT(*)") > 0 Then

                    For i As Integer = 1 To ds.Tables("cus_order_amount").Rows(0).Item("COUNT(*)")
                        If ds.Tables("cus_order").Rows(i - 1).Item("totalmoney") > 0 Then
                            Odsearch_dayL.Text &= "訂單編號: " & ds.Tables("cus_order").Rows(i - 1).Item("od_id") & "   訂單金額: " & ds.Tables("cus_order").Rows(i - 1).Item("totalmoney") & "   產生時間: " & ds.Tables("cus_order").Rows(i - 1).Item("generation_time") & vbNewLine
                        End If
                    Next
                Else
                    Odsearch_dayL.Text = "查無訂單"
                End If

                ds.Tables("cus_order").Clear()
                ds.Tables("cus_order_amount").Clear()
            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub Odsearch_id_btn_Click(sender As Object, e As EventArgs) Handles Odsearch_id_btn.Click
        Odsearch_idL.Text = ""

        If Odsearch_idT.Text <> "" Then
            Try
                cmd = "Select * FROM cus_order WHERE od_id=""" & Odsearch_idT.Text & """"
                adpt = New MySqlDataAdapter(cmd, Conn)
                adpt.Fill(ds, "cus_order")

                cmd = "Select amount, name FROM meals_amount,meals WHERE meals_amount.meals_id=meals.meals_id AND  order_id=""" & Odsearch_idT.Text & """ "
                adpt = New MySqlDataAdapter(cmd, Conn)
                adpt.Fill(ds, "meals_amount")

                cmd = "Select COUNT(*) FROM meals_amount WHERE order_id=""" & Odsearch_idT.Text & """"
                adpt = New MySqlDataAdapter(cmd, Conn)
                adpt.Fill(ds, "meals_count")

                If ds.Tables("cus_order").Rows(0).Item("totalmoney") = 0 Then
                    Odsearch_idL.Text = "此訂單已被刪除!"
                Else
                    Odsearch_idL.Text &= "訂單編號: " & ds.Tables("cus_order").Rows(0).Item("od_id") & vbNewLine _
                          & "訂單金額: " & ds.Tables("cus_order").Rows(0).Item("totalmoney") & vbNewLine _
                          & "辣度: " & ds.Tables("cus_order").Rows(0).Item("spicy") & vbNewLine _
                          & "產生時間: " & ds.Tables("cus_order").Rows(0).Item("generation_time") & vbNewLine

                    For i As Integer = 1 To ds.Tables("meals_count").Rows(0).Item("COUNT(*)")
                        If i = 1 Then
                            Odsearch_idL.Text &= "訂單食材: " & vbNewLine
                        End If
                        Odsearch_idL.Text &= "        " & ds.Tables("meals_amount").Rows(i - 1).Item("name") & ": " & ds.Tables("meals_amount").Rows(i - 1).Item("amount") & vbNewLine
                    Next

                    Odsearch_idL.Text &= "備註: " & ds.Tables("cus_order").Rows(0).Item("note") & vbNewLine
                End If



                ds.Tables("cus_order").Clear()
                ds.Tables("meals_amount").Clear()
                ds.Tables("meals_count").Clear()
            Catch ex As Exception
                Odsearch_idL.Text = ex.ToString
            End Try
        End If

    End Sub

    Private Sub Odsearch_delete_btn_Click(sender As Object, e As EventArgs) Handles Odsearch_delete_btn.Click
        If Odsearch_idT.Text <> "" Then
            cmd = "Select COUNT(*) FROM cus_order WHERE od_id=""" & Odsearch_idT.Text & """"
            adpt = New MySqlDataAdapter(cmd, Conn)
            adpt.Fill(ds, "order_count")
            If ds.Tables("order_count").Rows(0).Item("COUNT(*)") = 1 Then
                If MsgBox("確定刪除?", vbYesNo, "刪除訂單") = 6 Then
                    Conn.Open()
                    ccmd = Conn.CreateCommand
                    ccmd.CommandText = "UPDATE cus_order SET totalmoney=0 WHERE od_id = @od_id"

                    ccmd.Parameters.AddWithValue("@od_id", Odsearch_idT.Text)
                    ccmd.ExecuteNonQuery()
                    ccmd.Parameters.Clear()

                    ccmd = Conn.CreateCommand
                    ccmd.CommandText = "DELETE FROM meals_amount WHERE order_id = @od_id "

                    ccmd.Parameters.AddWithValue("@od_id", Odsearch_idT.Text)
                    ccmd.ExecuteNonQuery()
                    ccmd.Parameters.Clear()
                    Conn.Close()
                    MsgBox("刪除成功", vbYesNo, "刪除訂單")
                End If
            Else
                MsgBox("無此訂單", vbOKOnly, "錯誤")
            End If
            ds.Tables("order_count").Clear()
        End If
    End Sub

    Private Sub Odsearch_back_btn_Click(sender As Object, e As EventArgs) Handles Odsearch_back_btn.Click
        Odsearch_interface(False)
        Emp_interface(True)
    End Sub
    '訂單查詢介面結束





    '庫存管理介面
    Function Totalpages_inven() As String
        cmd = "Select COUNT(*) FROM meals "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")
        Dim re As String = Math.Ceiling(ds.Tables("meals_amount").Rows(0).Item("COUNT(*)") / 4).ToString

        ds.Tables("meals_amount").Clear()

        Return "第 " & pages & " / " & re & " 頁"
    End Function

    Private Sub Inventory_mealsupdate(pgs As Integer)
        Inventory_interface(False)
        Infoupdate = False
        For i As Integer = 0 To 27
            Info_change(i, 0) = ""
        Next

        cmd = "Select COUNT(*) FROM meals "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")
        meals_amount = ds.Tables("meals_amount").Rows(0).Item("COUNT(*)")

        If meals_amount >= pgs * 4 Then
            actual_amount = 4
        Else
            actual_amount = meals_amount Mod 4
        End If

        Inventory_interface(True, actual_amount)
        Inven_pagesL.Text = Totalpages_inven()


        cmd = "Select * FROM meals  ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals")

        For i As Integer = 0 To actual_amount - 1
            lb = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("image")
            lstr = New System.IO.MemoryStream(lb)

            Select Case i
                Case 0
                    Food1_pic_inven.Image = Image.FromStream(lstr)
                    Food1_nameT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("name")
                    Food1_invenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("inventory")
                    Food1_lowinvenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("lowinventory")
                    Food1_priceT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("price")
                    Food1_costT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("cost")
                    Food1_onsaleT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("onsale")
                    Food1_numT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("num")
                    Info_change(0, 0) = Food1_nameT.Text
                    Info_change(1, 0) = Food1_invenT.Text
                    Info_change(2, 0) = Food1_lowinvenT.Text
                    Info_change(3, 0) = Food1_priceT.Text
                    Info_change(4, 0) = Food1_costT.Text
                    Info_change(5, 0) = Food1_onsaleT.Text
                    Info_change(6, 0) = Food1_numT.Text
                Case 1
                    Food2_pic_inven.Image = Image.FromStream(lstr)
                    Food2_nameT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("name")
                    Food2_invenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("inventory")
                    Food2_lowinvenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("lowinventory")
                    Food2_priceT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("price")
                    Food2_costT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("cost")
                    Food2_onsaleT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("onsale")
                    Food2_numT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("num")
                    Info_change(7, 0) = Food2_nameT.Text
                    Info_change(8, 0) = Food2_invenT.Text
                    Info_change(9, 0) = Food2_lowinvenT.Text
                    Info_change(10, 0) = Food2_priceT.Text
                    Info_change(11, 0) = Food2_costT.Text
                    Info_change(12, 0) = Food2_onsaleT.Text
                    Info_change(13, 0) = Food2_numT.Text
                Case 2
                    Food3_pic_inven.Image = Image.FromStream(lstr)
                    Food3_nameT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("name")
                    Food3_invenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("inventory")
                    Food3_lowinvenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("lowinventory")
                    Food3_priceT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("price")
                    Food3_costT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("cost")
                    Food3_onsaleT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("onsale")
                    Food3_numT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("num")
                    Info_change(14, 0) = Food3_nameT.Text
                    Info_change(15, 0) = Food3_invenT.Text
                    Info_change(16, 0) = Food3_lowinvenT.Text
                    Info_change(17, 0) = Food3_priceT.Text
                    Info_change(18, 0) = Food3_costT.Text
                    Info_change(19, 0) = Food3_onsaleT.Text
                    Info_change(20, 0) = Food3_numT.Text
                Case 3
                    Food4_pic_inven.Image = Image.FromStream(lstr)
                    Food4_nameT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("name")
                    Food4_invenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("inventory")
                    Food4_lowinvenT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("lowinventory")
                    Food4_priceT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("price")
                    Food4_costT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("cost")
                    Food4_onsaleT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("onsale")
                    Food4_numT.Text = ds.Tables("meals").Rows(i + (pgs - 1) * 4).Item("num")
                    Info_change(21, 0) = Food4_nameT.Text
                    Info_change(22, 0) = Food4_invenT.Text
                    Info_change(23, 0) = Food4_lowinvenT.Text
                    Info_change(24, 0) = Food4_priceT.Text
                    Info_change(25, 0) = Food4_costT.Text
                    Info_change(26, 0) = Food4_onsaleT.Text
                    Info_change(27, 0) = Food4_numT.Text
            End Select
        Next

        Infoupdate = True

        ds.Tables("meals_amount").Clear()
        ds.Tables("meals").Clear()
    End Sub

    Private Sub Inventory_warning()
        Inven_warningL.Text = ""
        cmd = "Select name  FROM meals WHERE lowinventory>=inventory "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "Inventory_war")


        cmd = "Select COUNT(*)  FROM meals WHERE lowinventory>=inventory "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "Inventory_war_count")

        If ds.Tables("Inventory_war_count").Rows(0).Item("COUNT(*)") > 0 Then
            Inven_warningL.Text = "存量警告! : "
            For i As Integer = 1 To ds.Tables("Inventory_war_count").Rows(0).Item("COUNT(*)")
                Inven_warningL.Text &= ds.Tables("Inventory_war").Rows(i - 1).Item("name") & ", "
            Next
            Inven_warningL.Text = LSet(Inven_warningL.Text, InStrRev(Inven_warningL.Text, ",") - 1)
        End If

        ds.Tables("Inventory_war").Clear()
        ds.Tables("Inventory_war_count").Clear()
    End Sub

    Private Sub Inven_add_btn_Click(sender As Object, e As EventArgs) Handles Inven_add_btn.Click
        Inventory_interface(False)
        InvenAdd_interface(True)
    End Sub

    Private Sub Inven_right_Click(sender As Object, e As EventArgs) Handles Inven_right.Click
        cmd = "Select COUNT(*) FROM meals "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_amount")
        meals_amount = ds.Tables("meals_amount").Rows(0).Item("COUNT(*)")

        If pages * 4 < meals_amount Then
            pages += 1
            Inventory_mealsupdate(pages)
        End If

        ds.Tables("meals_amount").Clear()

    End Sub

    Private Sub Inven_left_Click(sender As Object, e As EventArgs) Handles Inven_left.Click
        If pages > 1 Then

            pages -= 1
            Inventory_mealsupdate(pages)
        End If
    End Sub

    Private Sub Inven_confirm_btn_Click(sender As Object, e As EventArgs) Handles Inven_confirm_btn.Click
        Infochangestr = ""
        For i As Integer = 0 To 27
            If Info_change(i, 1) <> "" Then
                Infochangestr &= "將" & Info_change(i, 0) & " 更改至 " & Info_change(i, 1) & vbNewLine
            End If
        Next

        If Infochangestr <> "" Then
            If MsgBox(Infochangestr, vbYesNo, "確定更改") = 6 Then
                Conn.Open()
                ccmd = Conn.CreateCommand
                ccmd.CommandText = "UPDATE meals SET name = @name, inventory=@inventory, lowinventory=@lowinventory, price=@price, cost=@cost ,onsale=@onsale, num=@num WHERE meals_id = ""meals_" & (1 + (pages - 1) * 4).ToString & """"
                ccmd.Parameters.AddWithValue("@name", Food1_nameT.Text)
                ccmd.Parameters.AddWithValue("@inventory", Food1_invenT.Text)
                ccmd.Parameters.AddWithValue("@lowinventory", Food1_lowinvenT.Text)
                ccmd.Parameters.AddWithValue("@price", Food1_priceT.Text)
                ccmd.Parameters.AddWithValue("@cost", Food1_costT.Text)
                ccmd.Parameters.AddWithValue("@onsale", Food1_onsaleT.Text)
                ccmd.Parameters.AddWithValue("@num", Food1_numT.Text)

                ccmd.ExecuteNonQuery()
                ccmd.Parameters.Clear()

                ccmd.CommandText = "UPDATE meals SET name = @name, inventory=@inventory, lowinventory=@lowinventory, price=@price, cost=@cost ,onsale=@onsale, num=@num WHERE meals_id = ""meals_" & (2 + (pages - 1) * 4).ToString & """"
                ccmd.Parameters.AddWithValue("@name", Food2_nameT.Text)
                ccmd.Parameters.AddWithValue("@inventory", Food2_invenT.Text)
                ccmd.Parameters.AddWithValue("@lowinventory", Food2_lowinvenT.Text)
                ccmd.Parameters.AddWithValue("@price", Food2_priceT.Text)
                ccmd.Parameters.AddWithValue("@cost", Food2_costT.Text)
                ccmd.Parameters.AddWithValue("@onsale", Food2_onsaleT.Text)
                ccmd.Parameters.AddWithValue("@num", Food2_numT.Text)

                ccmd.ExecuteNonQuery()
                ccmd.Parameters.Clear()

                ccmd.CommandText = "UPDATE meals SET name = @name, inventory=@inventory, lowinventory=@lowinventory, price=@price, cost=@cost ,onsale=@onsale, num=@num WHERE meals_id = ""meals_" & (3 + (pages - 1) * 4).ToString & """"
                ccmd.Parameters.AddWithValue("@name", Food3_nameT.Text)
                ccmd.Parameters.AddWithValue("@inventory", Food3_invenT.Text)
                ccmd.Parameters.AddWithValue("@lowinventory", Food3_lowinvenT.Text)
                ccmd.Parameters.AddWithValue("@price", Food3_priceT.Text)
                ccmd.Parameters.AddWithValue("@cost", Food3_costT.Text)
                ccmd.Parameters.AddWithValue("@onsale", Food3_onsaleT.Text)
                ccmd.Parameters.AddWithValue("@num", Food3_numT.Text)

                ccmd.ExecuteNonQuery()
                ccmd.Parameters.Clear()

                ccmd.CommandText = "UPDATE meals SET name = @name, inventory=@inventory, lowinventory=@lowinventory, price=@price, cost=@cost ,onsale=@onsale, num=@num WHERE meals_id = ""meals_" & (4 + (pages - 1) * 4).ToString & """"
                ccmd.Parameters.AddWithValue("@name", Food4_nameT.Text)
                ccmd.Parameters.AddWithValue("@inventory", Food4_invenT.Text)
                ccmd.Parameters.AddWithValue("@lowinventory", Food4_lowinvenT.Text)
                ccmd.Parameters.AddWithValue("@price", Food4_priceT.Text)
                ccmd.Parameters.AddWithValue("@cost", Food4_costT.Text)
                ccmd.Parameters.AddWithValue("@onsale", Food4_onsaleT.Text)
                ccmd.Parameters.AddWithValue("@num", Food4_numT.Text)

                ccmd.ExecuteNonQuery()
                ccmd.Parameters.Clear()

                Conn.Close()

                For i As Integer = 0 To 27
                    If Info_change(i, 1) <> "" Then
                        Info_change(i, 0) = Info_change(i, 1)
                        Info_change(i, 1) = ""
                    End If
                Next
            End If
        End If

        Dim mstream1 As New System.IO.MemoryStream()
        Food1_pic_inven.Image.Save(mstream1, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage1() As Byte = mstream1.GetBuffer()
        mstream1.Close()

        Conn.Open()
        ccmd = Conn.CreateCommand
        ccmd.CommandText = "UPDATE meals SET image = @image WHERE meals_id = ""meals_" & (1 + (pages - 1) * 4).ToString & """"
        ccmd.Parameters.AddWithValue("@image", arrImage1)
        ccmd.ExecuteNonQuery()
        ccmd.Parameters.Clear()

        Dim mstream2 As New System.IO.MemoryStream()
        Food2_pic_inven.Image.Save(mstream2, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage2() As Byte = mstream2.GetBuffer()
        mstream2.Close()


        ccmd = Conn.CreateCommand
        ccmd.CommandText = "UPDATE meals SET image = @image WHERE meals_id = ""meals_" & (2 + (pages - 1) * 4).ToString & """"
        ccmd.Parameters.AddWithValue("@image", arrImage2)
        ccmd.ExecuteNonQuery()
        ccmd.Parameters.Clear()

        Dim mstream3 As New System.IO.MemoryStream()
        Food3_pic_inven.Image.Save(mstream3, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage3() As Byte = mstream3.GetBuffer()
        mstream3.Close()


        ccmd = Conn.CreateCommand
        ccmd.CommandText = "UPDATE meals SET image = @image WHERE meals_id = ""meals_" & (3 + (pages - 1) * 4).ToString & """"
        ccmd.Parameters.AddWithValue("@image", arrImage3)
        ccmd.ExecuteNonQuery()
        ccmd.Parameters.Clear()

        Dim mstream4 As New System.IO.MemoryStream()
        Food4_pic_inven.Image.Save(mstream4, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage4() As Byte = mstream4.GetBuffer()
        mstream4.Close()


        ccmd = Conn.CreateCommand
        ccmd.CommandText = "UPDATE meals SET image = @image WHERE meals_id = ""meals_" & (4 + (pages - 1) * 4).ToString & """"
        ccmd.Parameters.AddWithValue("@image", arrImage4)
        ccmd.ExecuteNonQuery()
        ccmd.Parameters.Clear()

        Conn.Close()
    End Sub

    Private Sub Inven_back_btn_Click(sender As Object, e As EventArgs) Handles Inven_back_btn.Click
        Inventory_interface(False)
        Emp_interface(True)
        pages = 1
    End Sub

    Private Sub Food1_delete_btn_Click(sender As Object, e As EventArgs) Handles Food1_delete_btn.Click
        cmd = "Select meals_id FROM meals  ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_id")

        cmd = "Select COUNT(*) FROM meals  "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_count")


        If MsgBox("確定刪除?", vbYesNo, "刪除") = 6 Then
            Conn.Open()
            ccmd = Conn.CreateCommand
            ccmd.CommandText = "DELETE FROM meals WHERE meals_id = @meals_id"

            ccmd.Parameters.AddWithValue("@meals_id", ds.Tables("meals_id").Rows((pages - 1) * 4).Item("meals_id"))
            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()


            ccmd = Conn.CreateCommand
            ccmd.CommandText = "UPDATE meals SET meals_id=@new_id WHERE meals_id = @old_id"

            ccmd.Parameters.AddWithValue("@new_id", ds.Tables("meals_id").Rows((pages - 1) * 4).Item("meals_id"))
            ccmd.Parameters.AddWithValue("@old_id", "meals_" & ds.Tables("meals_count").Rows(0).Item("COUNT(*)").ToString)
            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()

            Conn.Close()
            Inventory_mealsupdate(pages)
        End If

        ds.Tables("meals_id").Clear()
        ds.Tables("meals_count").Clear()
    End Sub

    Private Sub Food2_delete_btn_Click(sender As Object, e As EventArgs) Handles Food2_delete_btn.Click
        cmd = "Select meals_id FROM meals  ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_id")

        cmd = "Select COUNT(*) FROM meals  "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_count")

        If MsgBox("確定刪除?", vbYesNo, "刪除") = 6 Then
            Conn.Open()

        ccmd = Conn.CreateCommand
        ccmd.CommandText = "DELETE FROM meals WHERE meals_id = @meals_id"

        ccmd.Parameters.AddWithValue("@meals_id", ds.Tables("meals_id").Rows(1 + (pages - 1) * 4).Item("meals_id"))
        ccmd.ExecuteNonQuery()
        ccmd.Parameters.Clear()


        ccmd = Conn.CreateCommand
        ccmd.CommandText = "UPDATE meals SET meals_id=@new_id WHERE meals_id = @old_id"

        ccmd.Parameters.AddWithValue("@new_id", ds.Tables("meals_id").Rows(1 + (pages - 1) * 4).Item("meals_id"))
        ccmd.Parameters.AddWithValue("@old_id", "meals_" & ds.Tables("meals_count").Rows(0).Item("COUNT(*)").ToString)
        ccmd.ExecuteNonQuery()
        ccmd.Parameters.Clear()

            Conn.Close()

            Inventory_mealsupdate(pages)
        End If
        ds.Tables("meals_id").Clear()
        ds.Tables("meals_count").Clear()
    End Sub

    Private Sub Food3_delete_btn_Click(sender As Object, e As EventArgs) Handles Food3_delete_btn.Click
        cmd = "Select meals_id FROM meals  ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_id")

        cmd = "Select COUNT(*) FROM meals  "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_count")
        If MsgBox("確定刪除?", vbYesNo, "刪除") = 6 Then
            Conn.Open()
            ccmd = Conn.CreateCommand

            ccmd.CommandText = "DELETE FROM meals WHERE meals_id = @meals_id"

            ccmd.Parameters.AddWithValue("@meals_id", ds.Tables("meals_id").Rows(2 + (pages - 1) * 4).Item("meals_id"))
            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()


            ccmd = Conn.CreateCommand
            ccmd.CommandText = "UPDATE meals SET meals_id=@new_id WHERE meals_id = @old_id"

            ccmd.Parameters.AddWithValue("@new_id", ds.Tables("meals_id").Rows(2 + (pages - 1) * 4).Item("meals_id"))
            ccmd.Parameters.AddWithValue("@old_id", "meals_" & ds.Tables("meals_count").Rows(0).Item("COUNT(*)").ToString)
            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()

            Conn.Close()

        Inventory_mealsupdate(pages)
        End If
        ds.Tables("meals_id").Clear()
        ds.Tables("meals_count").Clear()
    End Sub

    Private Sub Food4_delete_btn_Click(sender As Object, e As EventArgs) Handles Food4_delete_btn.Click
        cmd = "Select meals_id FROM meals  ORDER BY meals_id; "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_id")

        cmd = "Select COUNT(*) FROM meals  "
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_count")

        If MsgBox("確定刪除?", vbYesNo, "刪除") = 6 Then
            Conn.Open()

            ccmd = Conn.CreateCommand
            ccmd.CommandText = "DELETE FROM meals WHERE meals_id = @meals_id"

            ccmd.Parameters.AddWithValue("@meals_id", ds.Tables("meals_id").Rows(3 + (pages - 1) * 4).Item("meals_id"))
            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()


            ccmd = Conn.CreateCommand
            ccmd.CommandText = "UPDATE meals SET meals_id=@new_id WHERE meals_id = @old_id"

            ccmd.Parameters.AddWithValue("@new_id", ds.Tables("meals_id").Rows(3 + (pages - 1) * 4).Item("meals_id"))
            ccmd.Parameters.AddWithValue("@old_id", "meals_" & ds.Tables("meals_count").Rows(0).Item("COUNT(*)").ToString)
            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()

            Conn.Close()

            Inventory_mealsupdate(pages)
        End If
        ds.Tables("meals_id").Clear()
        ds.Tables("meals_count").Clear()
    End Sub

#Region "食材資訊更改"
    Private Sub Food1_nameT_TextChanged(sender As Object, e As EventArgs) Handles Food1_nameT.TextChanged
        If Infoupdate = True Then
            Info_change(0, 1) = sender.text
        End If
    End Sub

    Private Sub Food1_invenT_TextChanged(sender As Object, e As EventArgs) Handles Food1_invenT.TextChanged
        If Infoupdate = True Then
            Info_change(1, 1) = sender.text
        End If
    End Sub

    Private Sub Food1_lowinvenT_TextChanged(sender As Object, e As EventArgs) Handles Food1_lowinvenT.TextChanged
        If Infoupdate = True Then
            Info_change(2, 1) = sender.text
        End If
    End Sub

    Private Sub Food1_priceT_TextChanged(sender As Object, e As EventArgs) Handles Food1_priceT.TextChanged
        If Infoupdate = True Then
            Info_change(3, 1) = sender.text
        End If
    End Sub

    Private Sub Food1_costT_TextChanged(sender As Object, e As EventArgs) Handles Food1_costT.TextChanged
        If Infoupdate = True Then
            Info_change(4, 1) = sender.text
        End If
    End Sub

    Private Sub Food1_onsaleT_TextChanged(sender As Object, e As EventArgs) Handles Food1_onsaleT.TextChanged
        If Infoupdate = True Then
            Info_change(5, 1) = sender.text
        End If
    End Sub

    Private Sub Food1_numT_TextChanged(sender As Object, e As EventArgs) Handles Food1_numT.TextChanged
        If Infoupdate = True Then
            Info_change(6, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_nameT_TextChanged(sender As Object, e As EventArgs) Handles Food2_nameT.TextChanged
        If Infoupdate = True Then
            Info_change(7, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_invenT_TextChanged(sender As Object, e As EventArgs) Handles Food2_invenT.TextChanged
        If Infoupdate = True Then
            Info_change(8, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_lowinvenT_TextChanged(sender As Object, e As EventArgs) Handles Food2_lowinvenT.TextChanged
        If Infoupdate = True Then
            Info_change(9, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_priceT_TextChanged(sender As Object, e As EventArgs) Handles Food2_priceT.TextChanged
        If Infoupdate = True Then
            Info_change(10, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_costT_TextChanged(sender As Object, e As EventArgs) Handles Food2_costT.TextChanged
        If Infoupdate = True Then
            Info_change(11, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_onsaleT_TextChanged(sender As Object, e As EventArgs) Handles Food2_onsaleT.TextChanged
        If Infoupdate = True Then
            Info_change(12, 1) = sender.text
        End If
    End Sub

    Private Sub Food2_numT_TextChanged(sender As Object, e As EventArgs) Handles Food2_numT.TextChanged
        If Infoupdate = True Then
            Info_change(13, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_nameT_TextChanged(sender As Object, e As EventArgs) Handles Food3_nameT.TextChanged
        If Infoupdate = True Then
            Info_change(14, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_invenT_TextChanged(sender As Object, e As EventArgs) Handles Food3_invenT.TextChanged
        If Infoupdate = True Then
            Info_change(15, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_lowinvenT_TextChanged(sender As Object, e As EventArgs) Handles Food3_lowinvenT.TextChanged
        If Infoupdate = True Then
            Info_change(16, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_priceT_TextChanged(sender As Object, e As EventArgs) Handles Food3_priceT.TextChanged
        If Infoupdate = True Then
            Info_change(17, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_costT_TextChanged(sender As Object, e As EventArgs) Handles Food3_costT.TextChanged
        If Infoupdate = True Then
            Info_change(18, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_onsaleT_TextChanged(sender As Object, e As EventArgs) Handles Food3_onsaleT.TextChanged
        If Infoupdate = True Then
            Info_change(19, 1) = sender.text
        End If
    End Sub

    Private Sub Food3_numT_TextChanged(sender As Object, e As EventArgs) Handles Food3_numT.TextChanged
        If Infoupdate = True Then
            Info_change(20, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_nameT_TextChanged(sender As Object, e As EventArgs) Handles Food4_nameT.TextChanged
        If Infoupdate = True Then
            Info_change(21, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_invenT_TextChanged(sender As Object, e As EventArgs) Handles Food4_invenT.TextChanged
        If Infoupdate = True Then
            Info_change(22, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_lowinvenT_TextChanged(sender As Object, e As EventArgs) Handles Food4_lowinvenT.TextChanged
        If Infoupdate = True Then
            Info_change(23, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_priceT_TextChanged(sender As Object, e As EventArgs) Handles Food4_priceT.TextChanged
        If Infoupdate = True Then
            Info_change(24, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_costT_TextChanged(sender As Object, e As EventArgs) Handles Food4_costT.TextChanged
        If Infoupdate = True Then
            Info_change(25, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_onsaleT_TextChanged(sender As Object, e As EventArgs) Handles Food4_onsaleT.TextChanged
        If Infoupdate = True Then
            Info_change(26, 1) = sender.text
        End If
    End Sub

    Private Sub Food4_numT_TextChanged(sender As Object, e As EventArgs) Handles Food4_numT.TextChanged
        If Infoupdate = True Then
            Info_change(27, 1) = sender.text
        End If
    End Sub


#End Region

#Region "食材照片更改"
    Private Sub Food1_pic_inven_Click(sender As Object, e As EventArgs) Handles Food1_pic_inven.Click
        Dim opendialog As New OpenFileDialog()

        opendialog.Filter = "JPEG Files (*.jpg)|*.jpg"
        If (opendialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Food1_pic_inven.ImageLocation = opendialog.FileName
        End If

    End Sub

    Private Sub Food2_pic_inven_Click(sender As Object, e As EventArgs) Handles Food2_pic_inven.Click
        Dim opendialog As New OpenFileDialog()

        opendialog.Filter = "JPEG Files (*.jpg)|*.jpg"
        If (opendialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Food2_pic_inven.ImageLocation = opendialog.FileName
        End If

    End Sub

    Private Sub Food3_pic_inven_Click(sender As Object, e As EventArgs) Handles Food3_pic_inven.Click
        Dim opendialog As New OpenFileDialog()

        opendialog.Filter = "JPEG Files (*.jpg)|*.jpg"
        If (opendialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Food3_pic_inven.ImageLocation = opendialog.FileName
        End If

    End Sub

    Private Sub Food4_pic_inven_Click(sender As Object, e As EventArgs) Handles Food4_pic_inven.Click
        Dim opendialog As New OpenFileDialog()

        opendialog.Filter = "JPEG Files (*.jpg)|*.jpg"
        If (opendialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Food4_pic_inven.ImageLocation = opendialog.FileName
        End If

    End Sub
#End Region
    '庫存管理介面結束





    '新增庫存介面
    Private Sub InvenAdd_pic_Click(sender As Object, e As EventArgs) Handles InvenAdd_pic.Click
        Dim opendialog As New OpenFileDialog()

        opendialog.Filter = "JPEG Files (*.jpg)|*.jpg"
        If (opendialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            InvenAdd_pic.ImageLocation = opendialog.FileName
        End If
    End Sub

    Private Sub InvenAdd_confirm_btn_Click(sender As Object, e As EventArgs) Handles InvenAdd_confirm_btn.Click
        If InvenAdd_nameT.Text <> "" And InvenAdd_invenT.Text <> "" And InvenAdd_lowinvenT.Text <> "" And InvenAdd_priceT.Text <> "" And InvenAdd_costT.Text <> "" And InvenAdd_onsaleT.Text <> "" And InvenAdd_numT.Text <> "" Then
            cmd = "SELECT COUNT(*) FROM meals; "
            adpt = New MySqlDataAdapter(cmd, Conn)
            adpt.Fill(ds, "meals_amount")
            meals_amount = ds.Tables("meals_amount").Rows(0).Item("COUNT(*)")

            Dim mstream As New System.IO.MemoryStream()
            InvenAdd_pic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim arrImage() As Byte = mstream.GetBuffer()
            mstream.Close()



            Conn.Open()
            ccmd = Conn.CreateCommand
            ccmd.CommandText = "INSERT INTO meals (meals_id, name, inventory, lowinventory, price, cost, onsale, num, image)
                                       VALUES (@meals_id, @name, @inventory, @lowinventory, @price, @cost, @onsale, @num, @image)"
            ccmd.Parameters.AddWithValue("@meals_id", "meals_" + (meals_amount + 1).ToString)
            ccmd.Parameters.AddWithValue("@name", InvenAdd_nameT.Text)
            ccmd.Parameters.AddWithValue("@inventory", InvenAdd_invenT.Text)
            ccmd.Parameters.AddWithValue("@lowinventory", InvenAdd_lowinvenT.Text)
            ccmd.Parameters.AddWithValue("@price", InvenAdd_priceT.Text)
            ccmd.Parameters.AddWithValue("@cost", InvenAdd_costT.Text)
            ccmd.Parameters.AddWithValue("@onsale", InvenAdd_onsaleT.Text)
            ccmd.Parameters.AddWithValue("@num", InvenAdd_numT.Text)
            ccmd.Parameters.AddWithValue("@image", arrImage)
            ccmd.ExecuteNonQuery()

            ccmd.Parameters.Clear()
            Conn.Close()


            ds.Tables("meals_amount").Clear()
            InvenAdd_interface(False)
            Inventory_mealsupdate(pages)
        End If
    End Sub

    Private Sub InvenAdd_cancel_btn_Click(sender As Object, e As EventArgs) Handles InvenAdd_cancel_btn.Click
        InvenAdd_interface(False)
        Inventory_mealsupdate(pages)
    End Sub
    '新增庫存介面結束





    '修改密碼介面
    Private Sub Pass_confirm_btn_Click(sender As Object, e As EventArgs) Handles Pass_confirm_btn.Click
        If Pass_passT1.Text = Pass_passT2.Text Then
            Conn.Open()
            ccmd = Conn.CreateCommand
            ccmd.CommandText = "UPDATE clerk SET password = @password WHERE account =@account "
            ccmd.Parameters.AddWithValue("@password", Pass_passT1.Text)
            ccmd.Parameters.AddWithValue("@account", Account)

            ccmd.ExecuteNonQuery()
            ccmd.Parameters.Clear()
            MsgBox("修改成功", vbOKOnly, "成功")
            Pass_passT1.Text = ""
            Pass_passT2.Text = ""
            Pass_interface(False)
            Emp_interface(True)
            Conn.Close()
        Else
            MsgBox("確認密碼不一致", vbOKOnly, "錯誤")
        End If
    End Sub

    Private Sub Pass_cancel_btn_Click(sender As Object, e As EventArgs) Handles Pass_cancel_btn.Click
        Pass_passT1.Text = ""
        Pass_passT2.Text = ""
        Pass_interface(False)
        Emp_interface(True)
    End Sub
    '修改密碼介面結束




    '營業報表介面
    Private Sub Report_generate(Date_S As Date, Date_E As Date)
        Report_dateL.Text = ""
        Report_mealsL.Text = ""
        Report_moneyL.Text = ""
        Report_dateL.Text = Date_S.ToString & "  到  " & Date_E.ToString("s")
        Dim cost As Integer = 0
        Dim revenue As Integer = 0


        cmd = "SELECT name,SUM(amount) , SUM(amount)*price , SUM(amount)*cost FROM meals_amount,meals 
                        WHERE order_id IN(SELECT od_id FROM cus_order WHERE generation_time<='" & Date_E.ToString("s") & "' AND generation_time>='" & Date_S.ToString("s") & "')  
                        AND meals.meals_id=meals_amount.meals_id GROUP BY meals_amount.meals_id ORDER BY SUM(amount) DESC;"

        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_report")

        cmd = "SELECT COUNT(*) FROM meals 
                        WHERE meals.meals_id  in (SELECT DISTINCT meals_amount.meals_id FROM meals_amount 
                        WHERE order_id  IN(SELECT od_id FROM cus_order WHERE generation_time<='" & Date_E.ToString("s") & "' AND generation_time>='" & Date_S.ToString("s") & "'));"
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_report_conut")

        cmd = "SELECT name FROM meals WHERE meals.meals_id not in (SELECT DISTINCT meals_amount.meals_id FROM meals_amount 
                        WHERE order_id  IN(SELECT od_id FROM cus_order WHERE generation_time<='" & Date_E.ToString("s") & "' AND generation_time>='" & Date_S.ToString("s") & "'));"
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_not_report")

        cmd = "SELECT COUNT(*) FROM meals 
                        WHERE meals.meals_id not in (SELECT DISTINCT meals_amount.meals_id FROM meals_amount 
                        WHERE order_id  IN(SELECT od_id FROM cus_order WHERE generation_time<'" & Date_E.ToString("s") & "' AND generation_time>='" & Date_S.ToString("s") & "'));"
        adpt = New MySqlDataAdapter(cmd, Conn)
        adpt.Fill(ds, "meals_not_report_conut")


        If ds.Tables("meals_report_conut").Rows(0).Item("COUNT(*)") > 0 Then
            For i As Integer = 1 To ds.Tables("meals_report_conut").Rows(0).Item("COUNT(*)")
                Report_mealsL.Text &= ds.Tables("meals_report").Rows(i - 1).Item("name") & " : " & ds.Tables("meals_report").Rows(i - 1).Item("SUM(amount)") & "  份" & vbNewLine
                revenue += ds.Tables("meals_report").Rows(i - 1).Item("SUM(amount)*price")
                cost += ds.Tables("meals_report").Rows(i - 1).Item("SUM(amount)*cost")
            Next
        End If

        If ds.Tables("meals_not_report_conut").Rows(0).Item("COUNT(*)") > 0 Then

            For i As Integer = 1 To ds.Tables("meals_not_report_conut").Rows(0).Item("COUNT(*)")
                Report_mealsL.Text &= ds.Tables("meals_not_report").Rows(i - 1).Item("name") & " : 0份" & vbNewLine
            Next
        End If

        Report_moneyL.Text &= "營業額 : " & revenue & "元  成本 : " & cost & "元  利潤 : " & revenue - cost & "元"

        ds.Tables("meals_report").Clear()
        ds.Tables("meals_report_conut").Clear()
        ds.Tables("meals_not_report").Clear()
        ds.Tables("meals_not_report_conut").Clear()
    End Sub

    Private Sub Report_today_btn_Click(sender As Object, e As EventArgs) Handles Report_today_btn.Click
        Date_now = DateAndTime.Now
        Dim Date_start As Date
        Date_start = New Date(Date_now.Year, Date_now.Month, Date_now.Day, 0, 0, 0)

        Report_generate(Date_start, Date_now)
    End Sub

    Private Sub Report_week_btn_Click(sender As Object, e As EventArgs) Handles Report_week_btn.Click
        Date_now = DateAndTime.Now
        Dim Date_start As Date


        If Weekday(Date_now) > 2 Then
            Date_start = DateAdd("d", -(Weekday(Date_now) - 2), Date_now)
            Date_start = New Date(Date_start.Year, Date_start.Month, Date_start.Day, 0, 0, 0)
        End If

        Report_generate(Date_start, Date_now)
    End Sub

    Private Sub Report_month_btn_Click(sender As Object, e As EventArgs) Handles Report_month_btn.Click
        Date_now = DateAndTime.Now
        Dim Date_start As Date
        Date_start = New Date(Date_now.Year, Date_now.Month, 1, 0, 0, 0)

        Report_generate(Date_start, Date_now)
    End Sub

    Private Sub Report_season_btn_Click(sender As Object, e As EventArgs) Handles Report_season_btn.Click
        Date_now = DateAndTime.Now
        Dim Date_start As Date

        Select Case Date_now.Month
            Case 1, 2, 3
                Date_start = New Date(Date_now.Year, 1, 1, 0, 0, 0)
            Case 4, 5, 6
                Date_start = New Date(Date_now.Year, 4, 1, 0, 0, 0)
            Case 7, 8, 9
                Date_start = New Date(Date_now.Year, 7, 1, 0, 0, 0)
            Case 10, 11, 12
                Date_start = New Date(Date_now.Year, 10, 1, 0, 0, 0)
        End Select

        Report_generate(Date_start, Date_now)
    End Sub

    Private Sub Report_confirm_btn_Click(sender As Object, e As EventArgs) Handles Report_confirm_btn.Click
        Dim Date_start As Date = Report_start_date.Value
        Dim Date_end As Date = Report_end_date.Value
        Date_start = New Date(Date_start.Year, Date_start.Month, Date_start.Day, 0, 0, 0)
        Date_end = New Date(Date_end.Year, Date_end.Month, Date_end.Day, 0, 0, 0)

        Report_generate(Date_start, Date_end)
    End Sub

    Private Sub Report_back_btn_Click(sender As Object, e As EventArgs) Handles Report_back_btn.Click
        Report_interface(False)
        Emp_interface(True)
    End Sub

    '營業報表介面結束

End Class
