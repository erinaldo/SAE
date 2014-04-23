Imports MySql.Data.MySqlClient
Public Class FrmBusquedas

    Private Sub FrmBusquedas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DBCon.Open()
    End Sub

    Private Sub txtbusqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbusqueda.KeyDown
        CargarDatos()
    End Sub

    Public Sub CargarDatos()

        Dim Lector As MySqlDataReader
        Dim dt As New DataTable

        If DBCon.State = ConnectionState.Open Then
            Dim ComandoSQL As New MySqlCommand("SELECT codigo,descripcion FROM PUC WHERE descripcion LIKE '%" & txtbusqueda.Text & "%'", DBCon)
            Lector = ComandoSQL.ExecuteReader
            dt.Load(Lector)
            DataGridView1.DataSource = dt
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtbusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusqueda.TextChanged

    End Sub
End Class