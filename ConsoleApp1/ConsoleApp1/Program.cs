using System;
using System.Collections.Generic;
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
                    //if (!(item.Username == username && item.Password == password))
                    //{
                    //    Helper.Print("USername ve ya parol sehvdir ", ConsoleColor.Red);
                    //}
                    if (item.Username==username&&item.Password==password)
                    {
                        if (item.RoleType== RoleType.ADMIN)
                        {
                            Helper.Print("Siz admin rolundasiniz", ConsoleColor.Yellow);
                            admin:
                            Helper.Print("1.Admin Panel",ConsoleColor.Green);
                            Helper.Print("2.Satis et",ConsoleColor.Green);
                            Helper.Print("3.Melumatlari yenile",ConsoleColor.Green);
                            Helper.Print("4.Cixish",ConsoleColor.Green);
                            string nmenu = Console.ReadLine();
                            bool IsInt = int.TryParse(nmenu, out int menu);
                            if (!IsInt)
                            {
                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                goto admin;
                            }
                            if (menu==4)
                            {
                                goto login;
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
                                        goto admin;
                                    }
                                    switch (adminmenu)
                                    {
                                        case 1:
                                            #region addemploye
                                            pharmacy.AddEmplooye();
                                            goto admin;
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
                                    #region satis
                                    if (pharmacy.drugs.Count==0)
                                    {
                                        Helper.Print("Bazada derman yoxdu !!", ConsoleColor.Red);
                                        goto admin;
                                    }
                                    Helper.Print("Derman adi daxil edin", ConsoleColor.DarkYellow);
                                    string dad = Console.ReadLine();
                                    Helper.Print("Derman tipini qeyd edin: syrob/powder/tablet?", ConsoleColor.DarkYellow);
                                    string dyit = Console.ReadLine();
                                    dsay:
                                    Helper.Print("Sayini daxil edin", ConsoleColor.DarkYellow);
                                    string dsay = Console.ReadLine();
                                    bool isSay = int.TryParse(dsay, out int ddsay);
                                    if (!isSay)
                                    {
                                        Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.DarkRed);
                                        goto dsay;
                                    }

                                        List<Drug> drugess = pharmacy.drugs.FindAll(x => x.Name.ToUpper().Contains(dad.ToUpper()) && x.DrugType.ToString().ToUpper().Contains(dyit.ToUpper())&&x.Count>=ddsay);
                                        if (drugess.Count == 0)
                                        {
                                            Helper.Print("Qalmayib", ConsoleColor.Red);
                                            goto admin;
                                        }
                                    foreach (var druge in drugess)
                                    {
                                        Helper.Print($"ID:{druge.Id} AD:{druge.Name} Say:{druge.Count} Tip:{druge.DrugType} SAtis qiymeti:{druge.SalePrice}", ConsoleColor.Yellow);
                                        Helper.Print("Satis etmek istediynize eminsinizmi: yes/no?", ConsoleColor.Green);
                                        string yesno = Console.ReadLine();
                                        if (yesno.ToUpper()=="yes".ToUpper())
                                        {
                                            pharmacy.drugs.Remove(druge);
                                            pharmacy.Budget = pharmacy.Budget + (druge.SalePrice*druge.Count);
                                            Helper.Print($"{druge.Name} adli derman satildi maci<3", ConsoleColor.Blue);
                                        }
                                    }
                                    goto admin;
                                    break;
                                #endregion
                                case 3:
                                    #region uploadacont
                                    Helper.Print("Yeni adinizi daxil edin", ConsoleColor.Yellow);
                                    string nwname = Console.ReadLine();
                                    item.Name = nwname;
                                    Helper.Print("Yeni Soyadinizi daxil edin", ConsoleColor.Yellow);
                                    string nwsname = Console.ReadLine();
                                    item.Surname = nwsname;
                                    
                                eusername:
                                    Helper.Print("Yeni username daxil edin", ConsoleColor.Yellow);
                                    string eusername = Console.ReadLine();
                                    foreach (var item1 in pharmacy.employees)
                                    {
                                        if (item1.Username == eusername)
                                        {
                                            Helper.Print("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                                            goto eusername;
                                        }
                                    }
                                    item.Username = eusername;
                                    Helper.Print("Yeni Password daxil edin", ConsoleColor.Yellow);
                                    string nwpass = Console.ReadLine();
                                    item.Password = nwpass;
                                    Helper.Print("Melumatlar yenilendi maci", ConsoleColor.Blue);
                                    goto admin;
                                #endregion
                               
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
