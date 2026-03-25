using System;
using System.Collections.Generic;

class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Enfermedad { get; set; }

    public Paciente(int id, string nombre, int edad, string enfermedad)
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
        Enfermedad = enfermedad;
    }
}

class SistemaPacientes
{
    private List<Paciente> lista = new List<Paciente>();
    private int contador = 1;

    public void AgregarPaciente()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enfermedad: ");
        string enfermedad = Console.ReadLine();

        Paciente p = new Paciente(contador, nombre, edad, enfermedad);
        lista.Add(p);
        contador++;

        Console.WriteLine("Paciente agregado ✔");
    }

    public void VerPacientes()
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("No hay pacientes.");
            return;
        }

        Console.WriteLine("\nID | Nombre | Edad | Enfermedad");
        foreach (var p in lista)
        {
            Console.WriteLine($"{p.Id} | {p.Nombre} | {p.Edad} | {p.Enfermedad}");
        }
    }

    public void BuscarPaciente()
    {
        Console.Write("Ingrese ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var p = lista.Find(x => x.Id == id);

        if (p != null)
        {
            Console.WriteLine($"Nombre: {p.Nombre}");
            Console.WriteLine($"Edad: {p.Edad}");
            Console.WriteLine($"Enfermedad: {p.Enfermedad}");
        }
        else
        {
            Console.WriteLine("Paciente no encontrado");
        }
    }

    public void EliminarPaciente()
    {
        Console.Write("Ingrese ID a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var p = lista.Find(x => x.Id == id);

        if (p != null)
        {
            lista.Remove(p);
            Console.WriteLine("Paciente eliminado ✔");
        }
        else
        {
            Console.WriteLine("No encontrado");
        }
    }
}

SistemaPacientes sistema = new SistemaPacientes();
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- SISTEMA DE PACIENTES ---");
    Console.WriteLine("1. Agregar paciente");
    Console.WriteLine("2. Ver pacientes");
    Console.WriteLine("3. Buscar paciente");
    Console.WriteLine("4. Eliminar paciente");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione: ");

    int op;
    if (!int.TryParse(Console.ReadLine(), out op))
    {
        Console.WriteLine("Error, escriba un número");
        continue;
    }

    switch (op)
    {
        case 1: sistema.AgregarPaciente(); break;
        case 2: sistema.VerPacientes(); break;
        case 3: sistema.BuscarPaciente(); break;
        case 4: sistema.EliminarPaciente(); break;
        case 5: salir = true; break;
        default: Console.WriteLine("Opción incorrecta"); break;
    }
}
