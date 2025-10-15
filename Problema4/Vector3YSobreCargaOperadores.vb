Imports System
Imports System.Numerics

' Definición de la clase Vector3 para el problema 3 de sobrecarga de operadores
'
' Nota: Para los operadores & y % ya que no se pueden sobrecargar directamente porque tienen otras aplicaciones
' Se ha optado por usar los operadores Not y Mod respectivamente
'
Public Class Vector3
    Public Property X As Double
    Public Property Y As Double
    Public Property Z As Double

    ' Constructor
    Public Sub New(x As Double, y As Double, z As Double)
        Me.X = x
        Me.Y = y
        Me.Z = z
    End Sub

    ' Sobrecarga del operador +
    Public Shared Operator +(v1 As Vector3, v2 As Vector3) As Vector3
        Return New Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z)
    End Operator

    ' Sobrecarga del operador -
    Public Shared Operator -(v1 As Vector3, v2 As Vector3) As Vector3
        Return New Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z)
    End Operator

    ' Sobrecarga del operador unario - (negativo)
    Public Shared Operator -(v As Vector3) As Vector3
        Return New Vector3(-v.X, -v.Y, -v.Z)
    End Operator

    ' Sobrecarga del operador * (multiplicación por escalar por la derecha) 
    Public Shared Operator *(v As Vector3, scalar As Double) As Vector3
        Return New Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar)
    End Operator

    ' Sobrecarga del operador * (multiplicación por escalar por la izquierda) 
    Public Shared Operator *(scalar As Double, v As Vector3) As Vector3
        Return New Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar)
    End Operator

    ' Sobrecarga del operador Mod (productor punto (% No existe en visual basic, por tanto no se puede sobrecargar)) 
    Public Shared Operator Mod(v1 As Vector3, v2 As Vector3) As Double
        Return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z
    End Operator


    ' Sobrecarga del operador Not (Norma (& no se puede sobrecargar en Visual Basic por tanto uso el unario de Not))
    Public Shared Operator Not(v As Vector3) As Double
        Return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z)
    End Operator

    ' Método para mostrar vector
    Public Overrides Function ToString() As String
        Return $"({X}, {Y}, {Z})"
    End Function
End Class

Module Programa
    Sub Main()
        Dim a As New Vector3(2, 3, 6)
        Dim b As New Vector3(4, 1, 5)
        Dim c As New Vector3(5, 7, 2)
        Dim d As New Vector3(1, 8, 4)

        Dim r1 As Vector3 = -a + b * 2 - c + d
        Dim r2 As Vector3 = (a + b) * 2 - (c - d)
        Dim r3 As Double = (a Mod b) + (b Mod c) - (c Mod d) + (d Mod a)
        Dim r4 As Vector3 = -(-a + b) * 3 + c - d
        Dim r5 As Vector3 = a * 2 + b - c * 3 + d
        Dim r6 As Double = ((Not a) + (b Mod c)) - Not d
        Dim r7 As Vector3 = 5 * (a + b) + (c + d) + -a
        Dim r8 As Vector3 = a * 2 - (-b + c) * 3 + d
        Dim r9 As Double = (a Mod b) * 2 + (c Mod d) - Not b
        Dim r10 As Vector3 = -((a + b) * 2 - (c + d) * 3) + b

        Console.WriteLine($"r1 = {r1}")
        Console.WriteLine($"r2 = {r2}")
        Console.WriteLine($"r3 = {r3}")
        Console.WriteLine($"r4 = {r4}")
        Console.WriteLine($"r5 = {r5}")
        Console.WriteLine($"r6 = {r6}")
        Console.WriteLine($"r7 = {r7}")
        Console.WriteLine($"r8 = {r8}")
        Console.WriteLine($"r9 = {r9}")
        Console.WriteLine($"r10 = {r10}")
    End Sub
End Module