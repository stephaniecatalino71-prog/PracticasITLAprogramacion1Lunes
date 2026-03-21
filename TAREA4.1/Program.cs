using System;
using System.Collections.Generic;

// Clase Contacto
class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }
}

// Clase Agenda
class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();
    private int contador = 1;

    public void AgregarContacto()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        Contacto nuevo = new Contacto(contador++, nombre, telefono, email, direccion);
        contactos.Add(nuevo);

        Console.WriteLine("Contacto agregado ✔");
    }

    public void VerContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos.");
            return;
        }

        Console.WriteLine("\nID | Nombre | Teléfono | Email | Dirección");
        foreach (var c in contactos)
        {
            Console.WriteLine($"{c.Id} | {c.Nombre} | {c.Telefono} | {c.Email} | {c.Direccion}");
        }
    }

    public void BuscarContacto()
    {
        Console.Write("Ingrese ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var c = contactos.Find(x => x.Id == id);

        if (c != null)
        {
            Console.WriteLine($"Nombre: {c.Nombre}");
            Console.WriteLine($"Teléfono: {c.Telefono}");
            Console.WriteLine($"Email: {c.Email}");
            Console.WriteLine($"Dirección: {c.Direccion}");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado");
        }
    }

    public void EditarContacto()
    {
        Console.Write("Ingrese ID a editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var c = contactos.Find(x => x.Id == id);

        if (c != null)
        {
            Console.Write("Nuevo nombre: ");
            c.Nombre = Console.ReadLine();

            Console.Write("Nuevo teléfono: ");
            c.Telefono = Console.ReadLine();

            Console.Write("Nuevo email: ");
            c.Email = Console.ReadLine();

            Console.Write("Nueva dirección: ");
            c.Direccion = Console.ReadLine();

            Console.WriteLine("Contacto actualizado ✔");
        }
        else
        {
            Console.WriteLine("No encontrado");
        }
    }

    public void EliminarContacto()
    {
        Console.Write("Ingrese ID a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var c = contactos.Find(x => x.Id == id);

        if (c != null)
        {
            contactos.Remove(c);
            Console.WriteLine("Eliminado ✔");
        }
        else
        {
            Console.WriteLine("No encontrado");
        }
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== AGENDA =====");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Ver contactos");
            Console.WriteLine("3. Buscar contacto");
            Console.WriteLine("4. Editar contacto");
            Console.WriteLine("5. Eliminar contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida");
                continue;
            }

            switch (opcion)
            {
                case 1: agenda.AgregarContacto(); break;
                case 2: agenda.VerContactos(); break;
                case 3: agenda.BuscarContacto(); break;
                case 4: agenda.EditarContacto(); break;
                case 5: agenda.EliminarContacto(); break;
                case 6: running = false; break;
                default: Console.WriteLine("Opción inválida"); break;
            }
        }
    }
}
