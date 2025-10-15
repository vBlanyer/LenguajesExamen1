Imports System
Imports System.Collections.Generic

Public Class BuddySystem
    Private memoria() As String
    Private totalBloques As Integer

    ' Constructor
    Public Sub New(bloques As Integer)
        totalBloques = bloques
        ReDim memoria(totalBloques - 1)
        For i = 0 To totalBloques - 1
            memoria(i) = "LIBRE"
        Next
    End Sub

    ' Reserva memoria
    Public Sub Reservar(comando As String)
        Dim partes = comando.Split(" "c)
        If partes.Length < 3 Then
            Console.WriteLine("Uso: RESERVAR <cantidad> <nombre>")
            Return
        End If

        Dim cantidad As Integer = Integer.Parse(partes(1))
        Dim nombre As String = partes(2)

        ' Verificar si ya existe
        For Each b In memoria
            If b = nombre Then
                Console.WriteLine("Error: el nombre ya está reservado.")
                Return
            End If
        Next

        ' Buscar espacio libre contiguo
        Dim inicio As Integer = -1
        Dim libres As Integer = 0

        For i = 0 To totalBloques - 1
            If memoria(i) = "LIBRE" Then
                libres += 1
                If libres = cantidad Then
                    inicio = i - cantidad + 1
                    Exit For
                End If
            Else
                libres = 0
            End If
        Next

        If inicio = -1 Then
            Console.WriteLine("No hay suficiente espacio disponible.")
            Return
        End If

        ' Asignar bloques
        For i = inicio To inicio + cantidad - 1
            memoria(i) = nombre
        Next
        Console.WriteLine($"Se reservaron {cantidad} bloques para '{nombre}'.")
    End Sub

    ' Liberar memoria
    Public Sub Liberar(nombre As String)
        Dim existe As Boolean = False

        For i = 0 To totalBloques - 1
            If memoria(i) = nombre Then
                memoria(i) = "LIBRE"
                existe = True
            End If
        Next

        If existe Then
            Console.WriteLine($"Memoria liberada para '{nombre}'.")
        Else
            Console.WriteLine($"No se encontró ninguna reserva con el nombre '{nombre}'.")
        End If
    End Sub

    ' Mostrar memoria
    Public Sub Mostrar()
        Console.WriteLine(vbCrLf & "ESTADO DE LA MEMORIA (ESCALA DE BLOQUES EN POTENCIAS DE 2)")
        Console.WriteLine(New String("-"c, 80))

        Dim pot As Integer = 1
        While pot <= totalBloques
            Console.Write($"| {pot.ToString().PadLeft(3)} ")
            pot *= 2
        End While
        Console.WriteLine("|")
        Console.WriteLine(New String("-"c, 80))

        pot = 1
        While pot <= totalBloques
            Dim ocupado As Boolean = False
            For i = pot - 1 To Math.Min(pot * 2 - 2, totalBloques - 1)
                If memoria(i) <> "LIBRE" Then
                    ocupado = True
                    Exit For
                End If
            Next

            If ocupado Then
                Console.Write("|  *  ")
            Else
                Console.Write("|     ")
            End If

            pot *= 2
        End While

        Console.WriteLine("|")
        Console.WriteLine(New String("-"c, 80))
    End Sub
End Class

' Módulo de consola (ejecución manual)
Module SimuladorBuddySystem
    Sub Main()
        Console.WriteLine("SIMULADOR BUDDY SYSTEM")
        Console.Write("Ingrese la cantidad de bloques (potencia de 2): ")

        Dim totalBloques As Integer = Integer.Parse(Console.ReadLine())
        Dim sistema As New BuddySystem(totalBloques)

        Dim salir As Boolean = False
        While Not salir
            Console.WriteLine(vbCrLf & "Acciones: RESERVAR / LIBERAR / MOSTRAR / SALIR")
            Console.Write(">> ")
            Dim comando As String = Console.ReadLine().Trim()

            Select Case True
                Case comando.ToUpper().StartsWith("RESERVAR")
                    sistema.Reservar(comando)
                Case comando.ToUpper().StartsWith("LIBERAR")
                    Dim partes = comando.Split(" "c)
                    If partes.Length >= 2 Then
                        sistema.Liberar(partes(1))
                    Else
                        Console.WriteLine("Uso: LIBERAR <nombre>")
                    End If
                Case comando.ToUpper() = "MOSTRAR"
                    sistema.Mostrar()
                Case comando.ToUpper() = "SALIR"
                    salir = True
                Case Else
                    Console.WriteLine("Comando no reconocido.")
            End Select
        End While

        Console.WriteLine("Programa finalizado.")
    End Sub
End Module