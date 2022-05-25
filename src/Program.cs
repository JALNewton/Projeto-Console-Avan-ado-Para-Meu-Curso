using System;
using System.IO;
using System.Threading;

namespace _230522
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Log.SetDefaultColor();
            try
            {
                string senha = "123", senhaUser;
                int tentativas = 0, maxTentativas = 5;
                bool loginSucess = false;
                
                Console.Title = "xiiiu segredo a senha não é 123!";
                Console.Write("Olá, seja bem vindo(a) ao programa NOVOTEC! por gentileza informe a senha de acesso: ");

                while(tentativas < maxTentativas && !loginSucess)
                {     
                    tentativas++;
                    senhaUser = Console.ReadLine();  
                    Console.Clear();
                    if(senhaUser != senha)
                    {
                        Log.Write(string.Format("Senha incorreta! tentativas restantes: {0}\n- Deseja tentar novamente? digite SIM(s) NÃO(n):", maxTentativas - tentativas + 1));

                        string tTemp = Console.ReadLine().ToLower();
                        Console.Clear();
                        if( tTemp.ToLower() == "s") 
                        {
                            Console.Write("Digite a senha novamente: ");
                            continue;                    
                        }
                        else if (tTemp.ToLower() == "n")                    
                        {
                            
                            Log.Write("Neste caso como não deseja tentar novamente, verifique com algum superior se está com problemas em seu acesso!",4);                    
                            Thread.Sleep(5000);
                            return;
                        }
                        else       
                        {             
                            Log.Write("Não compreendi, por segurança o programa será encerrado em 5 segundos verifique com algum superior se está com problemas em seu acesso!",4);       
                            Thread.Sleep(5000);
                            return;
                        }
                        
                    }
                    else
                    {
                        Log.Write(string.Format("Parabéns! acesso liberado. total de tentativas: {0}", tentativas));
                        loginSucess = true;
                        Thread.Sleep(1000);
                        GetAcess();
                    }
                }
                Console.Clear();                
                if(tentativas >= maxTentativas)
                {
                    Log.Write("Tentativas excedidas! por segurança o programa será encerrado em 5 segundos verifique com algum superior se está com problemas em seu acesso!",0);
                    Thread.Sleep(5000);             
                }
            }
            catch(Exception ex)
            {
                Log.Write(ex.Message);
            }
            finally 
            {
                Log.Close();    
            }
        }

         private static void GetAcess()
         {
             Log.Write("Ops! Seu acesso não lhe servi para absolutamente nada, parabéns! programa encerrando...", 4);
             Thread.Sleep(7000);   
         }      
    }
    
    //Gerando arquivo de LOG.

    public static class Log
    {
        private static StreamWriter streamFile = new StreamWriter("Log.txt");
        private static ConsoleColor DefaultColor;
        public static void Write(string textToWrite_)
        {
            Console.WriteLine(textToWrite_);
            streamFile.WriteLine(textToWrite_);
        }

        public static void Write(object textToWrite_)
        {
            Console.WriteLine(textToWrite_);
            streamFile.WriteLine(textToWrite_);
        }
        public static void Write(string textToWrite_, ConsoleColor colorText)
        {
            Console.ForegroundColor = colorText;
            Console.WriteLine(textToWrite_);
            Console.ForegroundColor = DefaultColor;
            streamFile.WriteLine(textToWrite_);
        }

        public static void Write(string textToWrite_, int idColorText)
        {
            /*
                0: red
                1: blue
                2: green
                3: gray
                4: yellow
                5: white
                default: black // none
            */

            switch(idColorText)
            {
                case 0: 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                case 1: 
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                }
                case 2: 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                }
                case 3: 
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                case 4: 
                {
                   Console.ForegroundColor = ConsoleColor.Yellow;                    
                    break;
                }
                default:
                    Console.ForegroundColor = DefaultColor;
                    break;
            }
            Console.WriteLine(textToWrite_);
            Console.ForegroundColor = DefaultColor;
            streamFile.WriteLine(textToWrite_);
        }

        public static void Write(string textToWrite_, string idColorText)
        {
            switch(idColorText)
            {
                case "Red": 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                case "Blue": 
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                }
                case "Green": 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                }
                case "Gray": 
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                case "Yellow": 
                {
                   Console.ForegroundColor = ConsoleColor.Yellow;                    
                    break;
                }
                case "Black": 
                {
                   Console.ForegroundColor = ConsoleColor.Yellow;                    
                    break;
                }
                default:
                    Console.ForegroundColor = DefaultColor;
                    break;
            }
            Console.WriteLine(textToWrite_);
            Console.ForegroundColor = DefaultColor;
            streamFile.WriteLine(textToWrite_);
        }

        public static void SetDefaultColor()
        {
             DefaultColor = Console.ForegroundColor;
        }

        public static void Close()
        {
            streamFile.Close();
        }
    }
}