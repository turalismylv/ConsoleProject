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
            admin.Name = "admin";
            pharmacy.employees.Add(admin);
            login:
            Helper.Print("Login",ConsoleColor.Green);
            while (true)
            {
                Helper.Print("Username daxil edin",ConsoleColor.Green);
                string username = Console.ReadLine();
                Helper.Print("Password daxil edin", ConsoleColor.Green);
                string password = Console.ReadLine();   //SEHV DAXIL ETDIKDE ERROR QALIB!!!!!
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
                                #region adminpanel
                                adminmenu:
                                    Helper.Print("1.Emplooye elave et", ConsoleColor.Green);
                                    Helper.Print("2.Drug elave et", ConsoleColor.Green);
                                    Helper.Print("3.Drug sil", ConsoleColor.Green);
                                    Helper.Print("4.Derman editle", ConsoleColor.Green);
                                    Helper.Print("5.Emplooye sil", ConsoleColor.Green);
                                    Helper.Print("6.Emplooye editle", ConsoleColor.Green);
                                    Helper.Print("7. Cixish", ConsoleColor.Green);
                                    string adminmen = Console.ReadLine();
                                    bool IsInt1 = int.TryParse(adminmen, out int adminmenu);
                                    if (!IsInt1)
                                    {
                                        Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    if (adminmenu==7)
                                    {
                                        goto login;
                                    }
                                    switch (adminmenu)
                                    {
                                        case 1:
                                            #region addemploye
                                            pharmacy.AddEmplooye();
                                            goto login;
                                            break;
                                        #endregion
                                        case 2:
                                            #region adddrug
                                            pharmacy.AddDrug();
                                            goto adminmenu;
                                            break;
                                        #endregion
                                        case 3:
                                            #region delete drug 
                                            pharmacy.DeletDrug();
                                            goto adminmenu;
                                            break;
                                        #endregion
                                        case 4:
                                            #region editdurg
                                            pharmacy.EditDrug();
                                            goto adminmenu;
                                            break;
                                        #endregion
                                        case 5:
                                            #region deletemplooye
                                            pharmacy.DeletEmploye();
                                            goto login;
                                            break;
                                        #endregion
                                        case 6:
                                            #region editemployee
                                            pharmacy.EditEmploye();
                                            goto adminmenu;
                                            break;
                                        #endregion
                                        default:
                                            break;
                                    }
                                    break;
                                #endregion
                                case 2:
                                    Helper.Print("Derman adi daxil edin", ConsoleColor.DarkYellow);
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
