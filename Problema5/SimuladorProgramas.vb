Imports System
Imports System.Collections.Generic

Public Class Simulador

    ' Variable para definir el lenguaje máquina
    Public Property LenguajeMaquina As String = "LOCAL"
    ' Listas para almacenar programas, intérpretes y traductores
    Private ReadOnly programas As New List(Of Programa)
    Private ReadOnly interpretes As New List(Of Interprete)
    Private ReadOnly traductores As New List(Of Traductor)

    ' Clase para representar un programa
    Public Class Programa
        Public Property Nombre As String
        Public Property Lenguaje As String
        Public Sub New(nombre As String, lenguaje As String)
            Me.Nombre = nombre
            Me.Lenguaje = lenguaje
        End Sub
    End Class

    ' Clase para representar un intérprete
    Public Class Interprete
        Public Property LenguajeBase As String
        Public Property Lenguaje As String
        Public Sub New(lenguajeBase As String, lenguaje As String)
            Me.LenguajeBase = lenguajeBase
            Me.Lenguaje = lenguaje
        End Sub
    End Class

    ' Clase para representar un traductor
    Public Class Traductor
        Public Property LenguajeBase As String
        Public Property LenguajeOrigen As String
        Public Property LenguajeDestino As String
        Public Sub New(lenguajeBase As String, lenguajeOrigen As String, lenguajeDestino As String)
            Me.LenguajeBase = lenguajeBase
            Me.LenguajeOrigen = lenguajeOrigen
            Me.LenguajeDestino = lenguajeDestino
        End Sub
    End Class

    ' Metodo para agregar programas
    Public Sub AgregarPrograma(nombre As String, lenguaje As String)
        programas.Add(New Programa(nombre, lenguaje))
    End Sub

    ' Metodo para agregar intérpretes
    Public Sub AgregarInterprete(lenguajeBase As String, lenguaje As String)
        interpretes.Add(New Interprete(lenguajeBase, lenguaje))
    End Sub

    ' Metodo para agregar traductores
    Public Sub AgregarTraductor(lenguajeBase As String, lenguajeOrigen As String, lenguajeDestino As String)
        traductores.Add(New Traductor(lenguajeBase, lenguajeOrigen, lenguajeDestino))
    End Sub

    ' Funcion para ejecutar un programa
    Public Function EjecutarPrograma(nombrePrograma As String) As List(Of String)
        Dim resultado As New List(Of String)
        Dim programa = programas.Find(Function(p) p.Nombre = nombrePrograma)
        If programa Is Nothing Then
            resultado.Add($"Error: Programa '{nombrePrograma}' no encontrado.")
            Return resultado
        End If

        Dim lenguajeActual = programa.Lenguaje
        Dim grafo As New List(Of String) From {lenguajeActual}
        resultado.Add($"Iniciando ejecución de '{nombrePrograma}' en '{lenguajeActual}'.")

        While lenguajeActual <> LenguajeMaquina
            Dim interprete = interpretes.Find(Function(i) i.Lenguaje = lenguajeActual AndAlso i.LenguajeBase = LenguajeMaquina)
            If interprete IsNot Nothing Then
                resultado.Add($"Interpretando '{lenguajeActual}' a '{LenguajeMaquina}'.")
                lenguajeActual = LenguajeMaquina
                grafo.Add(lenguajeActual)
                Exit While
            End If

            Dim traductor = traductores.Find(Function(t) t.LenguajeOrigen = lenguajeActual)
            If traductor IsNot Nothing Then
                resultado.Add($"Traduciendo '{lenguajeActual}' a '{traductor.LenguajeDestino}'.")
                lenguajeActual = traductor.LenguajeDestino
                grafo.Add(lenguajeActual)
            Else
                resultado.Add($"Error: No se puede ejecutar '{nombrePrograma}'. Falta traductor o intérprete.")
                Exit While
            End If
        End While

        resultado.Add(String.Join("->", grafo))
        Return resultado
    End Function
End Class

' Modulo principal
Module SimuladorProgramas
    Dim sim As New Simulador()

    ' Interfaz de consola para interactuar con el simulador
    Sub Interfaz()
        While True
            Console.Write("> ")
            Dim comando = Console.ReadLine()
            Dim p = comando.Split(" "c)
            Dim accion = p(0).ToUpper()

            Select Case accion
                Case "DEFINIR"
                    If p.Length >= 4 Then
                        Dim tipo = p(1).ToUpper()
                        Select Case tipo
                            Case "PROGRAMA" : sim.AgregarPrograma(p(2), p(3))
                            Case "INTERPRETE" : sim.AgregarInterprete(p(2), p(3))
                            Case "TRADUCTOR" : sim.AgregarTraductor(p(2), p(3), p(4))
                            Case Else : Console.WriteLine("Tipo inválido.")
                        End Select
                    Else
                        Console.WriteLine("Comando DEFINIR inválido.")
                    End If

                Case "EJECUTAR"
                    If p.Length = 2 Then
                        Dim resultado = sim.EjecutarPrograma(p(1))
                        For Each linea In resultado
                            Console.WriteLine(linea)
                        Next
                    Else
                        Console.WriteLine("Comando EJECUTAR inválido.")
                    End If

                Case "SALIR"
                    Exit While
                Case Else
                    Console.WriteLine("Comando no reconocido.")
            End Select
        End While
    End Sub

    Sub Main()
        Console.WriteLine("Simulador de Programas, Intérpretes y Traductores")
        Console.WriteLine("Comandos:")
        Console.WriteLine("  DEFINIR PROGRAMA <nombre> <lenguaje>")
        Console.WriteLine("  DEFINIR INTERPRETE <lenguaje_base> <lenguaje>")
        Console.WriteLine("  DEFINIR TRADUCTOR <lenguaje_base> <lenguaje_origen> <lenguaje_destino>")
        Console.WriteLine("  EJECUTAR <nombre_programa>")
        Console.WriteLine("  SALIR")
        Interfaz()
    End Sub
End Module