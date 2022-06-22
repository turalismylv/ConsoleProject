using System;
using ConsoleApp1.Helpers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pharmacy pharmacy = new Pharmacy("Zeferan",200,10000,"Sabuncu.Zabrat");
            Employee admin = new Employee();
            admin.Username = "admin";
            admin.Password = "admin123";
            admin.RoleType = RoleType.ADMIN;
            pharmacy.employees.Add(admin);
            login:
            Helper.Print("Login",ConsoleColor.Green);
            while (true)
            {
                
                Helper.Print("Username daxil edin",ConsoleColor.Green);
                string username = Console.ReadLine();
                Helper.Print("Password daxil edin", ConsoleColor.Green);
                string password = Console.ReadLine();

                foreach (var item in pharmacy.employees)
                {
                    if (item.Username==username&&item.Password==password)
                    {
                        if (item.RoleType== RoleType.ADMIN)
                        {
                            Helper.Print("Siz admin rolundasiniz", ConsoleColor.Yellow);
                            admin:
                            Helper.Print("1.Admin Panel",ConsoleColor.Green);
                            Helper.Print("2.Satis et",ConsoleColor.Green);
                            Helper.Print("3.Melumatlari yenile",ConsoleColor.Green);
                            string nmenu = Console.ReadLine();
                            bool IsInt = int.TryParse(nmenu, out int menu);
                            if (!IsInt)
                            {
                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                goto admin;
                            }
                            switch (menu)
                            {
                                case 1:
                                  
                                    Helper.Print("1.Emplooye elave et", ConsoleColor.Green);
                                    Helper.Print("2.Drug elave et", ConsoleColor.Green);
                                    Helper.Print("3.Drug sil", ConsoleColor.Green);
                                    Helper.Print("4.Derman editle", ConsoleColor.Green);
                                    Helper.Print("5.Emplooye sil", ConsoleColor.Green);
                                    Helper.Print("6.Emplooye editle", ConsoleColor.Green);
                                    string adminmen = Console.ReadLine();
                                    bool IsInt1 = int.TryParse(adminmen, out int adminmenu);
                                    if (!IsInt1)
                                    {
                                        Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    switch (adminmenu)
                                    {
                                        case 1:
                                            Helper.Print("Emplooye name daxil edin", ConsoleColor.Yellow);
                                            string ename = Console.ReadLine();
                                            Helper.Print("Emplooye surname daxil edin", ConsoleColor.Yellow);
                                            string sname = Console.ReadLine();
                                            dateTime:
                                            Helper.Print("Emplooye dogum tarixini qeyd edin ", ConsoleColor.Yellow);
                                            string edate = Console.ReadLine();
                                            bool isDate = DateTime.TryParse(edate, out DateTime dateTime);
                                            if (!isDate)
                                            {
                                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                                goto dateTime;
                                            }
                                            esalary:
                                            Helper.Print("Emplooye salary qeyd edin ", ConsoleColor.Yellow);
                                            string esal = Console.ReadLine();
                                            bool IsSal = int.TryParse(esal, out int esalary);
                                            if (!IsSal)
                                            {
                                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                                goto esalary;
                                            }
                                            if (esalary>pharmacy.MinSalary)
                                            {
                                                Helper.Print("Aptek bu maasi qarshilaya bilmir, zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                                goto esalary;
                                            }
                                            eusername:
                                            Helper.Print("Emplooye username daxil edin", ConsoleColor.Yellow);
                                            string eusername = Console.ReadLine();
                                            foreach (var item1 in pharmacy.employees)
                                            {
                                                if (item1.Username==eusername)
                                                {
                                                    Helper.Print("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                                                    goto eusername;
                                                }
                                            }
                                            Helper.Print("Emplooye password daxil edin", ConsoleColor.Yellow);
                                            string epassword = Console.ReadLine(); //Password yoxlanisi yazmalisan !!
                                            Helper.Print("Emplooye roletype qeyd edin: Admin/Staff? ", ConsoleColor.Yellow);
                                            string erole = Console.ReadLine();
                                            Employee employee1 = new Employee();
                                            employee1.Name = ename;
                                            employee1.Surname = sname;
                                            employee1.BirthDate = dateTime;
                                            employee1.Salary = esalary;
                                            employee1.Username = eusername;
                                            employee1.Password = epassword;
                                            if (erole == "admin")
                                            {
                                                employee1.RoleType = RoleType.ADMIN;
                                            }
                                            else if (erole== "staff")
                                            {
                                                employee1.RoleType = RoleType.STAFF;
                                            }
                                            
                                            Helper.Print($"{ename} adli emplooye yaradildi", ConsoleColor.Yellow);
                                            pharmacy.employees.Add(employee1);
                                            goto login;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (item.RoleType == RoleType.STAFF)
                        {
                            Helper.Print("1.Satis et", ConsoleColor.Green);
                            Helper.Print("2.Melumatlari yenile", ConsoleColor.Green);
                        }
                    }
                    
                    
                    
                }
            }
            
        }
    }
}
