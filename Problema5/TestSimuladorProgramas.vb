Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SimuladorProgramas

<TestClass>
Public Class SimuladorTests

    ' Traductor directo a LOCAL
    <TestMethod>
    Public Sub Test1()
        Dim sim As New Simulador()
        sim.AgregarPrograma("Test", "Python")
        sim.AgregarTraductor("LOCAL", "Python", "LOCAL")

        Dim resultado = sim.EjecutarPrograma("Test")

        Assert.IsTrue(resultado.Exists(Function(x) x.Contains("Python->LOCAL")))
    End Sub

    ' Interprete directo a LOCAL
    <TestMethod>
    Public Sub Test2()
        Dim sim As New Simulador()
        sim.AgregarPrograma("Test2", "Java")
        sim.AgregarInterprete("LOCAL", "Java")

        Dim resultado = sim.EjecutarPrograma("Test2")

        Assert.IsTrue(resultado.Exists(Function(x) x.Contains("Java->LOCAL")))
    End Sub

    ' Programa no existe
    <TestMethod>
    Public Sub test3()
        Dim sim As New Simulador()

        Dim resultado = sim.EjecutarPrograma("NoExiste")

        Assert.IsTrue(resultado.Exists(Function(x) x.Contains("Error: Programa 'NoExiste' no encontrado.")))
    End Sub

    ' No hay traductor ni interprete
    <TestMethod>
    Public Sub test4()
        Dim sim As New Simulador()
        sim.AgregarPrograma("Test3", "Ruby")

        Dim resultado = sim.EjecutarPrograma("Test3")

        Assert.IsTrue(resultado.Exists(Function(x) x.Contains("Error: No se puede ejecutar 'Test3'.")))
    End Sub

    ' Cadena de traductores e interprete
    <TestMethod>
    Public Sub test5()
        Dim sim As New Simulador()
        sim.AgregarPrograma("Test4", "C")
        sim.AgregarTraductor("LOCAL", "C", "Python")
        sim.AgregarTraductor("LOCAL", "Python", "Java")
        sim.AgregarInterprete("LOCAL", "Java")

        Dim resultado = sim.EjecutarPrograma("Test4")

        Assert.IsTrue(resultado.Exists(Function(x) x.Contains("C->Python->Java->LOCAL")))
    End Sub
End Class