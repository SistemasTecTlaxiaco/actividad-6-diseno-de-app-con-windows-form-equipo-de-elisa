using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp
{
    internal class Program
    {
            static List<Cita> citas = new List<Cita>();
            static List<string> horariosDisponibles = new List<string> { "9:00 AM", "10:00 AM", "11:00 AM", "2:00 PM", "3:00 PM" };

            static void Main()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("--- Gestión de Citas Médicas ---");
                    Console.WriteLine("1. Reservar cita");
                    Console.WriteLine("2. Cancelar cita");
                    Console.WriteLine("3. Salir");
                    Console.Write("Seleccione una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            ReservarCita();
                            break;
                        case "2":
                            CancelarCita();
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                            Console.ReadLine();
                            break;
                    }
                }
            }

            static void ReservarCita()
            {
                Console.Clear();
                Console.WriteLine("--- Reservar Cita ---");
                Console.Write("Nombre del paciente: ");
                string nombre = Console.ReadLine();
                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.Write("Motivo: ");
                string motivo = Console.ReadLine();

                Console.WriteLine("Horarios disponibles:");
                for (int i = 0; i < horariosDisponibles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {horariosDisponibles[i]}");
                }

                Console.Write("Seleccione un horario (número): ");
                int seleccion;
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion > 0 && seleccion <= horariosDisponibles.Count)
                {
                    string horarioSeleccionado = horariosDisponibles[seleccion - 1];
                    citas.Add(new Cita { Paciente = nombre, Telefono = telefono, Motivo = motivo, Horario = horarioSeleccionado });
                    horariosDisponibles.RemoveAt(seleccion - 1);
                    Console.WriteLine("Cita reservada con éxito. Presione Enter para continuar...");
                }
                else
                {
                    Console.WriteLine("Selección inválida. Presione Enter para continuar...");
                }
                Console.ReadLine();
            }

            static void CancelarCita()
            {
                Console.Clear();
                Console.WriteLine("--- Cancelar Cita ---");
                if (citas.Count == 0)
                {
                    Console.WriteLine("No hay citas para cancelar. Presione Enter para continuar...");
                    Console.ReadLine();
                    return;
                }

                for (int i = 0; i < citas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {citas[i].Paciente} - {citas[i].Horario}");
                }

                Console.Write("Seleccione una cita para cancelar (número): ");
                int seleccion;
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion > 0 && seleccion <= citas.Count)
                {
                    string horarioLiberado = citas[seleccion - 1].Horario;
                    horariosDisponibles.Add(horarioLiberado);
                    citas.RemoveAt(seleccion - 1);
                    Console.WriteLine("Cita cancelada con éxito. Presione Enter para continuar...");
                }
                else
                {
                    Console.WriteLine("Selección inválida. Presione Enter para continuar...");
                }
                Console.ReadLine();
            }
        }

        class Cita
        {
            public string Paciente { get; set; }
            public string Telefono { get; set; }
            public string Motivo { get; set; }
            public string Horario { get; set; }
        }

    }

