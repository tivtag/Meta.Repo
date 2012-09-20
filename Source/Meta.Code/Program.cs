using System;

namespace Meta.Code
{
    class Program
    {
        static System.Text.StringBuilder code = new System.Text.StringBuilder();

        static void Main( string[] args ) 
        {
            Compose(
                @"using System; namespace Meta.Code { class Program { static System.Text.StringBuilder code = new System.Text.StringBuilder(); static void Main( string[] args ) { Compose( ", @"); Console.Write( code ); string exe = new string( new char[] { 'M', 'e', 't', 'a', '.', 'B', 'u', 'i', 'l', 'd', 'e', 'r', '.', 'e', 'x', 'e' } ); string sendableCode = code.ToString().Replace( '\u0022', 'z' ); System.Diagnostics.Process.Start( new System.Diagnostics.ProcessStartInfo( exe, sendableCode ) ); } static void Compose( string header, string trail ) { Write( header ); Write( '@' ); Write( '\u0022' ); Write( header ); Write( '\u0022' ); Write( ',' ); Write( '@' ); Write( '\u0022' ); Write( trail ); Write( '\u0022' ); Write( trail ); } static void Write( string text ) { code.Append( text ); } static void Write( char ch ) { Write( ch.ToString() ); } } }"
            );

            Console.Write( code );
            string exe = new string( new char[] { 'M', 'e', 't', 'a', '.', 'B', 'u', 'i', 'l', 'd', 'e', 'r', '.', 'e', 'x', 'e' } ); 
            string sendableCode = code.ToString().Replace( '\u0022', 'z' ); 
            System.Diagnostics.Process.Start( new System.Diagnostics.ProcessStartInfo( exe, sendableCode ) );
        } 
        
        static void Compose( string header, string trail ) 
        {
            Write( header ); Write( '@' ); Write( '\u0022' ); Write( header ); Write( '\u0022' ); Write( ',' ); Write( '@' ); Write( '\u0022' ); Write( trail ); Write( '\u0022' ); Write( trail );
        }
        
        static void Write( string text ) { code.Append( text ); }
        static void Write( char ch ) { Write( ch.ToString() ); }
    }
}
