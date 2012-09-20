
namespace Meta.Builder
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;

    public static class Program
    {
        public static void Main( string[] args )
        {
            if( args.Length == 0 )
            {
                Console.WriteLine( "Hmm? You have given me no code to process.. Have a nice day!" );
                Console.Read();
                return;
            }

            string code = args.Aggregate( (total, agg) => total += " " + agg );
            code = code.Replace( 'z', '\u0022' );
            code = code.Replace( "\'\"\'", "\'z\'" ); 

            var codeProvider = Microsoft.CSharp.CSharpCodeProvider.CreateProvider( "C#" );
            var result = codeProvider.CompileAssemblyFromSource(
                new CompilerParameters( new string[] { "System.dll" } ) {
                    GenerateInMemory = true,
                    GenerateExecutable = true
                },
                code.ToString()
            );
            
            if( result.Errors.HasErrors )
            {
                Console.WriteLine( "Compilation Errors :\r\n" );

                foreach( CompilerError error in result.Errors )
                {
                    Console.WriteLine( 
                        "Line {0},{1}\t: {2}\n",
                        error.Line, error.Column, error.ErrorText
                    );
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine( "Reproduce? Y/N?" );
                Console.WriteLine();

                if( Console.ReadKey().Key == ConsoleKey.Y )
                {
                    result.CompiledAssembly.EntryPoint.Invoke( null, new object[] { new string[0] } );
                }
            }
        }
    }
}

