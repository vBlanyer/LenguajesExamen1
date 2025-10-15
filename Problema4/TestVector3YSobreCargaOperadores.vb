Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Vector3YSobreCargaOperadores

Namespace TestVector3YSobreCargaOperadores
    <TestClass>
    Public Class TestVector3YSobreCargaOperadores

        Private ReadOnly a As New Vector3(2, 3, 6)
        Private ReadOnly b As New Vector3(4, 1, 5)
        Private ReadOnly c As New Vector3(5, 7, 2)
        Private ReadOnly d As New Vector3(1, 8, 4)

        <TestMethod>
        Public Sub Test_R1()
            ' r1 = -a + b * 2 - c + d
            Dim r1 As Vector3 = -a + b * 2 - c + d
            Assert.AreEqual(2, r1.X)
            Assert.AreEqual(0, r1.Y)
            Assert.AreEqual(6, r1.Z)
        End Sub

        <TestMethod>
        Public Sub Test_R2()
            ' r2 = (a + b) * 2 - (c - d)
            Dim r2 As Vector3 = (a + b) * 2 - (c - d)
            Assert.AreEqual(8, r2.X)
            Assert.AreEqual(9, r2.Y)
            Assert.AreEqual(24, r2.Z)
        End Sub

        <TestMethod>
        Public Sub Test_R3()
            ' r3 = (a Mod b) + (b Mod c) - (c Mod d) + (d Mod a)
            Dim r3 As Double = (a Mod b) + (b Mod c) - (c Mod d) + (d Mod a)
            Assert.AreEqual(59, r3)
        End Sub

        <TestMethod>
        Public Sub Test_R4()
            ' r4 = -(-a + b) * 3 + c - d
            Dim r4 As Vector3 = -(-a + b) * 3 + c - d
            Assert.AreEqual(-2, r4.X)
            Assert.AreEqual(5, r4.Y)
            Assert.AreEqual(1, r4.Z)
        End Sub

        <TestMethod>
        Public Sub Test_R5()
            ' r5 = a * 2 + b - c * 3 + d
            Dim r5 As Vector3 = a * 2 + b - c * 3 + d
            Assert.AreEqual(-6, r5.X)
            Assert.AreEqual(-6, r5.Y)
            Assert.AreEqual(15, r5.Z)
        End Sub

        <TestMethod>
        Public Sub Test_R6()
            ' r6 = ((Not a) + (b Mod c)) - Not d
            Dim r6 As Double = ((Not a) + (b Mod c)) - Not d
            Assert.AreEqual(35, r6)
        End Sub

        <TestMethod>
        Public Sub Test_R7()
            ' r7 = 5 * (a + b) + (c + d) + -a
            Dim r7 As Vector3 = 5 * (a + b) + (c + d) + -a
            Assert.AreEqual(34, r7.X)
            Assert.AreEqual(32, r7.Y)
            Assert.AreEqual(55, r7.Z)
        End Sub

        <TestMethod>
        Public Sub Test_R8()
            ' r8 = a * 2 - (-b + c) * 3 + d
            Dim r8 As Vector3 = a * 2 - (-b + c) * 3 + d
            Assert.AreEqual(2, r8.X)
            Assert.AreEqual(-4, r8.Y)
            Assert.AreEqual(25, r8.Z)
        End Sub

        <TestMethod>
        Public Sub Test_R9()
            ' r9 = (a Mod b) * 2 + (c Mod d) - Not b
            Dim r9 As Double = (a Mod b) * 2 + (c Mod d) - Not b
            Assert.AreEqual(144.51925930159214, r9)
        End Sub

        <TestMethod>
        Public Sub Test_R10()
            ' r10 = -((a + b) * 2 - (c + d) * 3) + b
            Dim r10 As Vector3 = -((a + b) * 2 - (c + d) * 3) + b
            Assert.AreEqual(10, r10.X)
            Assert.AreEqual(38, r10.Y)
            Assert.AreEqual(1, r10.Z)
        End Sub

    End Class
End Namespace