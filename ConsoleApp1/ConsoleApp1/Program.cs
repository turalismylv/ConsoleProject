using ConsoleApp1.Helpers;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Zeferan.Aptek SISTEMINE XOSH GELMISINIZ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Helper.Printslow(s, ConsoleColor.Yellow);
            Pharmacy pharmacy = new Pharmacy("Zeferan.Aptek",200,1000,"Sabuncu.Zabrat");
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
                login1:
                Helper.Print("Username daxil edin",ConsoleColor.Green);
                string username = Console.ReadLine();
                Helper.Print("Password daxil edin", ConsoleColor.Green);
                string password = Console.ReadLine();   
                foreach (var item in pharmacy.employees)
                {
                    if (item.Username==username&&item.Password==password)
                    {
                        Console.Clear();
                        if (item.RoleType== RoleType.ADMIN)
                        {
                            Helper.Printslow("Siz admin rolundasiniz", ConsoleColor.Yellow);
                            admin:
                            Helper.Print("1.Admin Panel",ConsoleColor.Green);
                            Helper.Print("2.Satis et",ConsoleColor.Green);
                            Helper.Print("3.Melumatlari yenile",ConsoleColor.Green);
                            Helper.Print("4.Cixish",ConsoleColor.Green);
                            string nmenu = Console.ReadLine();
                            bool IsInt = int.TryParse(nmenu, out int menu);
                            if (!IsInt)
                            {
                                Console.Clear();
                                Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                goto admin;
                            }
                            if (menu==4)
                            {
                                Console.Clear();
                                goto login;
                            }
                            if (menu>4)
                            {
                                Console.Clear();
                                Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
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
                                    Helper.Print("4.Drug editle", ConsoleColor.Green);
                                    Helper.Print("5.Emplooye sil", ConsoleColor.Green);
                                    Helper.Print("6.Emplooye editle", ConsoleColor.Green);
                                    Helper.Print("7.Emplooyeleri gor", ConsoleColor.Green);
                                    Helper.Print("8.Druglari gor", ConsoleColor.Green);
                                    Helper.Print("9. Cixish", ConsoleColor.Green);
                                    string adminmen = Console.ReadLine();
                                    
                                    bool IsInt1 = int.TryParse(adminmen, out int adminmenu);
                                    if (!IsInt1)
                                    {
                                        Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    
                                    if (adminmenu==9)
                                    {
                                        goto admin;
                                    }
                                    if (adminmenu>9)
                                    {
                                        Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    switch (adminmenu)
                                    {

                                        case 1:
                                            #region addemploye
                                            
                                            pharmacy.AddEmplooye();
                                            
                                            goto admin;
                                            
                                        #endregion
                                        case 2:
                                            #region adddrug
                                            pharmacy.AddDrug();
                                            goto adminmenu;
                                           
                                        #endregion
                                        case 3:
                                            #region delete drug 
                                            pharmacy.DeletDrug();
                                            goto adminmenu;
                                            
                                        #endregion
                                        case 4:
                                            #region editdurg
                                            pharmacy.EditDrug();
                                            goto adminmenu;
                                            
                                        #endregion
                                        case 5:
                                            #region deletemplooye
                                            pharmacy.DeletEmploye();
                                            goto adminmenu;
                                            
                                        #endregion
                                        case 6:
                                            #region editemployee
                                            pharmacy.EditEmploye();
                                            goto adminmenu;

                                        #endregion
                                        case 7:
                                            #region seeemploye
                                            Console.Clear();
                                            foreach (var itemm in pharmacy.employees)
                                            {
                                                
                                                Helper.Print($"ID: {itemm.Id} Fullname: {itemm.Name} {itemm.Surname} Birthdate: {itemm.BirthDate} Salary: {itemm.Salary} Roletype: {itemm.RoleType}", ConsoleColor.DarkMagenta);
                                            }
                                            goto adminmenu;
                                        #endregion
                                        case 8:
                                            #region seedrug
                                            pharmacy.SeeDrug();
                                            goto adminmenu;
                                            #endregion
                                        default:
                                            break;
                                    }
                                    break;
                                #endregion
                                case 2:
                                    #region satis
                                    pharmacy.Sale();
                                    goto admin;
                                   
                                #endregion
                                case 3:
                                    #region uploadacont
                                    if (item.Name=="admin")
                                    {
                                        Console.Clear();
                                        Helper.Printslow("Siz SUPERADMIN olduqunuz ucun melumatlariniz yenilene bilmez", ConsoleColor.Red);
                                        goto admin;
                                        
                                    }
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
                                            Helper.Printslow("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                                            goto eusername;
                                        }
                                    }
                                    item.Username = eusername;
                                SETPASS:
                                    Helper.Print("Emplooye password daxil edin", ConsoleColor.Yellow);

                                    string npassword = Console.ReadLine();
                                    if (npassword.Length >= 5)
                                    {
                                        var hasNumber = new Regex(@"[0-9]+");
                                        var hasUpperChar = new Regex(@"[A-Z]+");
                                        var hasMiniMaxChars = new Regex(@".{6,15}");
                                        var hasLowerChar = new Regex(@"[a-z]+");
                                        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                                        if (!hasLowerChar.IsMatch(npassword))
                                        {
                                            Helper.Printslow("Passwordda kicik herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else if (!hasUpperChar.IsMatch(npassword))
                                        {
                                            Helper.Printslow("Passwordda boyuk herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else if (!hasMiniMaxChars.IsMatch(npassword))
                                        {
                                            Helper.Printslow("Passwordda uzunluqu 8~15 araliqinda deyil,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else if (!hasNumber.IsMatch(npassword))
                                        {
                                            Helper.Printslow("Passwordda reqem yoxdur!,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }

                                        else if (!hasSymbols.IsMatch(npassword))
                                        {
                                            Helper.Printslow("Passwordda xususi ishare yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else
                                        {

                                            item.Password = npassword;
                                        }
                                    }
                                    else
                                    {
                                        Helper.Printslow("Passwordda uzunluqu 5den azdir  ,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                        goto SETPASS;
                                    }
                                    Console.Clear();
                                    Helper.Printslow("Melumatlar yenilendi", ConsoleColor.Blue);
                                    goto admin;
                                #endregion
                                default:
                                    break;
                            }
                        }
                        else if (item.RoleType == RoleType.STAFF)
                        {
                            staff:
                            Helper.Print("1.Satis et", ConsoleColor.Green);
                            Helper.Print("2.Melumatlari yenile", ConsoleColor.Green);
                            Helper.Print("3.Druglari gor", ConsoleColor.Green);
                            Helper.Print("4.Cixish", ConsoleColor.Green);
                            string snum = Console.ReadLine();
                            bool isSme = int.TryParse(snum, out int smenu);
                            if (!isSme)
                            {
                                Console.Clear();
                                Helper.Printslow("Yanlis daxil edildi,Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                goto staff;
                            }
                            if (smenu==4)
                            {
                                Console.Clear();
                                goto login;
                            }
                            if (smenu>4)
                            {
                                Console.Clear();
                                Helper.Printslow("Yanlis daxil edildi,Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                goto staff;
                            }
                            switch (smenu)
                            {
                                case 1:
                                    pharmacy.Sale();
                                    goto staff;
                                   
                                case 2:
                                    #region uploadacont
                                    Helper.Print("Yeni adinizi daxil edin", ConsoleColor.Yellow);
                                    string nwname1 = Console.ReadLine();
                                    item.Name = nwname1;
                                    Helper.Print("Yeni Soyadinizi daxil edin", ConsoleColor.Yellow);
                                    string nwsname1 = Console.ReadLine();
                                    item.Surname = nwsname1;

                                eusername:
                                    Helper.Print("Yeni username daxil edin", ConsoleColor.Yellow);
                                    string eusername1 = Console.ReadLine();
                                    foreach (var item1 in pharmacy.employees)
                                    {
                                        if (item1.Username == eusername1)
                                        {
                                            Helper.Printslow("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                                            goto eusername;
                                        }
                                    }
                                    item.Username = eusername1;
                                SETPASS:
                                    Helper.Print("Emplooye password daxil edin", ConsoleColor.Yellow);
                                    string npassword1 = Console.ReadLine();
                                    if (npassword1.Length >= 5)
                                    {
                                        var hasNumber = new Regex(@"[0-9]+");
                                        var hasUpperChar = new Regex(@"[A-Z]+");
                                        var hasMiniMaxChars = new Regex(@".{6,15}");
                                        var hasLowerChar = new Regex(@"[a-z]+");
                                        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                                        if (!hasLowerChar.IsMatch(npassword1))
                                        {
                                            Helper.Printslow("Passwordda kicik herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else if (!hasUpperChar.IsMatch(npassword1))
                                        {
                                            Helper.Printslow("Passwordda boyuk herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else if (!hasMiniMaxChars.IsMatch(npassword1))
                                        {
                                            Helper.Printslow("Passwordda uzunluqu 8~15 araliqinda deyil,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else if (!hasNumber.IsMatch(npassword1))
                                        {
                                            Helper.Printslow("Passwordda reqem yoxdur!,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }

                                        else if (!hasSymbols.IsMatch(npassword1))
                                        {
                                            Helper.Printslow("Passwordda xususi ishare yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                            goto SETPASS;
                                        }
                                        else
                                        {

                                            item.Password = npassword1;
                                        }
                                    }
                                    else
                                    {
                                        Helper.Printslow("Passwordda uzunluqu 5den azdir  ,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                        goto SETPASS;
                                    }
                                    Console.Clear();
                                    Helper.Printslow("Melumatlar yenilendi", ConsoleColor.Blue);
                                    goto staff;
                                #endregion
                                case 3:
                                    #region seedrug
                                    pharmacy.SeeDrug();
                                    goto staff;
                                    #endregion
                                    
                                default:
                                    break;
                            }
                        }
                    }
                }
                Console.Clear();
                Helper.Printslow("Yanlis daxil edildi,Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto login1;
            }
            
        }
    }
}
