Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO

Public Class CSVDocument

    Private CSVContent As New List(Of List(Of String))

#Region "Load"

    '' ##
    '' ## Load
    '' ##

    Public Function Load(FileName As String, Optional Separator As Char = ";") As Boolean
        Try
            Dim Text As String() = File.ReadAllLines(FileName)

            For Each Row As String In Text
                Dim Temp As New List(Of String)

                For Each Col As String In Row.Split(Separator)
                    Temp.Add(Col)
                Next

                CSVContent.Add(Temp)
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    Public Function Load(ByRef Content As List(Of List(Of String))) As Boolean
        Try
            CSVContent = Content
            Return True
        Catch
            Return False
        End Try
    End Function

#End Region


#Region "Save"

    '' ##
    '' ## Save
    '' ##

    Public Function Save(FileName As String, Optional Separator As Char = ";") As Boolean
        Try
            Dim Text(GetRowsCount()) As String

            For I As Integer = 0 To GetRowsCount() - 1 Step 1
                Dim Temp As String = ""

                For Y As Integer = 0 To GetColsCount() - 1 Step 1
                    Temp &= CSVContent(I)(Y) & Separator
                Next

                Text(I) = Temp.Substring(0, Temp.Length - 1)
            Next

            File.WriteAllLines(FileName, Text)
            Return True
        Catch
            Return False
        End Try
    End Function


    Public Function Save(ByRef Content As List(Of List(Of String))) As Boolean
        Try
            Content = CSVContent
            Return True
        Catch
            Return False
        End Try
    End Function

#End Region


#Region "Element"

    '' ##
    '' ## Get Element
    '' ##

    Public Function GetElement(Row As Integer, Col As Integer) As String
        Try
            If Row > GetRowsCount() - 1 Or Col > GetColsCount() - 1 Then
                Return ""
            End If

            If Row < 0 Or Col < 0 Then
                Return ""
            End If

            Return CSVContent(Row)(Col)
        Catch
            Return ""
        End Try
    End Function


    '' ##
    '' ## Set Element
    '' ##

    Public Function SetElement(Row As Integer, Col As Integer, Value As String)
        Try
            If Row > GetRowsCount() - 1 Or Col > GetColsCount() - 1 Then
                Return ""
            End If

            If Row < 0 Or Col < 0 Then
                Return ""
            End If

            CSVContent(Row)(Col) = Value
            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ## Swap Element
    '' ##

    Public Function SwapElement(Row1 As Integer, Col1 As Integer, Row2 As Integer, Col2 As Integer) As Boolean
        Try
            Dim Element1 As String = GetElement(Row1, Col1)
            Dim Element2 As String = GetElement(Row2, Col2)

            If Element1 Is Nothing Or Element2 Is Nothing Then
                Return False
            End If

            If Not SetElement(Row1, Col1, Element2) Then
                Return False
            End If

            If Not SetElement(Row2, Col2, Element1) Then
                Return False
            End If

            Return True
        Catch
            Return False
        End Try
    End Function

#End Region


#Region "Row"

    '' ##
    '' ##   Get Row
    '' ##

    Public Function GetRow(Row As Integer) As List(Of String)
        If Row > GetRowsCount() - 1 Or Row < 0 Then
            Return Nothing
        End If

        Return CSVContent(Row)
    End Function


    Public Function GetFirstRow() As List(Of String)
        Return GetRow(0)
    End Function


    Public Function GetLastRow() As List(Of String)
        Return GetRow(GetRowsCount() - 1)
    End Function


    Public Function GetFirstElementInRow() As String
        Return GetFirstRow()(0)
    End Function


    Public Function GetLastElementInRow() As String
        Return GetLastRow()(GetColsCount() - 1)
    End Function


    '' ##
    '' ##   Set Row
    '' ##

    Public Function SetRow(Row As Integer, Value As String) As Boolean
        If Row > GetRowsCount() - 1 Or Row < 0 Then
            Return False
        End If

        Try
            For I As Integer = 0 To GetColsCount() - 1 Step 1
                SetElement(Row, I, Value)
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ##   Swap Row
    '' ##

    Public Function SwapRow(Row1 As Integer, Row2 As Integer) As Boolean
        If Row1 > GetRowsCount() - 1 Or Row2 > GetRowsCount() - 1 Then
            Return False
        End If

        If Row1 < 0 Or Row2 < 0 Then
            Return False
        End If

        For I As Integer = 0 To GetColsCount() - 1 Step 1
            If Not SwapElement(Row1, I, Row2, I) Then
                Return False
            End If
        Next

        Return True
    End Function


    '' ##
    '' ##   Add Row
    '' ##

    Public Function AddRow() As Boolean
        Try
            CSVContent.Add(New List(Of String))
            Return True
        Catch
            Return False
        End Try
    End Function


    Public Function AddRowAt(Index As Integer) As Boolean
        Try
            CSVContent.Insert(0, New List(Of String))
            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ##   Remove Row
    '' ##

    Public Function RemoveRow() As Boolean
        Try
            CSVContent.RemoveAt(GetRowsCount() - 1)
            Return True
        Catch
            Return False
        End Try
    End Function


    Public Function RemoveRowAt(Index As Integer) As Boolean
        Try
            CSVContent.RemoveAt(Index)
            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ##   Get Rows Count
    '' ##

    Public Function GetRowsCount() As Integer
        Return CSVContent.Count()
    End Function

#End Region


#Region "Col"

    '' ##
    '' ## Get Col
    '' ##

    Public Function GetCol(Col As Integer) As List(Of String)
        If Col > GetColsCount() - 1 Or Col < 0 Then
            Return Nothing
        End If

        Dim Temp As New List(Of String)

        For I As Integer = 0 To GetRowsCount() - 1 Step 1
            Temp.Add(CSVContent(I)(Col))
        Next

        Return Temp
    End Function


    Public Function GetFirstCol() As List(Of String)
        Return GetCol(0)
    End Function


    Public Function GetLastCol() As List(Of String)
        Return GetCol(GetColsCount() - 1)
    End Function


    Public Function GetFirstElementInCol() As String
        Return GetFirstCol()(0)
    End Function


    Public Function GetLastElementInCol() As String
        Return GetLastCol()(GetRowsCount() - 1)
    End Function


    '' ##
    '' ## Set Col
    '' ##

    Public Function SetCol(Col As Integer, Value As String) As Boolean
        If Col > GetColsCount() - 1 Or Col < 0 Then
            Return False
        End If

        Try
            For I As Integer = 0 To GetRowsCount() - 1 Step 1
                SetElement(I, Col, Value)
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ##   Swap Col
    '' ##

    Public Function SwapCol(Col1 As Integer, Col2 As Integer) As Boolean
        If Col1 > GetColsCount() - 1 Or Col2 > GetColsCount() - 1 Then
            Return False
        End If

        If Col1 < 0 Or Col2 < 0 Then
            Return False
        End If

        For I As Integer = 0 To GetRowsCount() - 1 Step 1
            If Not SwapElement(I, Col1, I, Col2) Then
                Return False
            End If
        Next

        Return True
    End Function


    '' ##
    '' ##   Add Col
    '' ##

    Public Function AddCol() As Boolean
        Try
            For Each L As List(Of String) In CSVContent
                L.Add("")
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    Public Function AddColAt(Index As Integer) As Boolean
        Try
            If Index > GetColsCount() - 1 Then
                Return False
            End If

            For Each L As List(Of String) In CSVContent
                L.Insert(Index, "")
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ##   Remove Col
    '' ##

    Public Function RemoveCol() As Boolean
        Try
            For Each L As List(Of String) In CSVContent
                L.RemoveAt(GetColsCount() - 1)
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    Public Function RemoveColAt(Index As Integer) As Boolean
        Try
            If Index > GetColsCount() - 1 Then
                Return False
            End If

            For Each L As List(Of String) In CSVContent
                L.RemoveAt(Index)
            Next

            Return True
        Catch
            Return False
        End Try
    End Function


    '' ##
    '' ##   Get Cols Count
    '' ##

    Public Function GetColsCount() As Integer
        Return CSVContent(0).Count()
    End Function

#End Region

End Class
