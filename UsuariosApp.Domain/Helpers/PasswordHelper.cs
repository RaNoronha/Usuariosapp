using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Helpers
{
    public class PasswordHelper
    {
        private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
        private static readonly string specialCharacters = "!@#$%&*";
        private static readonly string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string numericChars = "0123456789";

        public static string GeneratePassword()
        {
            int passwordLength = 8; // Tamanho mínimo da senha
            int specialCharacterCount = 1; // Número mínimo de caracteres especiais

            int totalChars = passwordLength - specialCharacterCount - 2; // 2 para a letra maiúscula e minúscula

            char[] password = new char[passwordLength];

            password[0] = GetRandomCharFrom(uppercaseChars);
            password[1] = GetRandomCharFrom(lowercaseChars);

            for (int i = 0; i < specialCharacterCount; i++)
            {
                password[2 + i] = specialCharacters[GetRandomIndex(specialCharacters.Length)];
            }

            for (int i = 0; i < totalChars; i++)
            {
                int charType = GetRandomIndex(3);

                switch (charType)
                {
                    case 0:
                        password[specialCharacterCount + 2 + i] = GetRandomCharFrom(numericChars);
                        break;
                    case 1:
                        password[specialCharacterCount + 2 + i] = GetRandomCharFrom(uppercaseChars);
                        break;
                    case 2:
                        password[specialCharacterCount + 2 + i] = GetRandomCharFrom(lowercaseChars);
                        break;
                }
            }

            ShufflePassword(password);

            return new string(password);
        }

        private static char GetRandomCharFrom(string chars)
        {
            int randomIndex = GetRandomIndex(chars.Length);
            return chars[randomIndex];
        }

        private static int GetRandomIndex(int length)
        {
            byte[] randomBytes = new byte[1];
            rng.GetBytes(randomBytes);
            return randomBytes[0] % length;
        }

        private static void ShufflePassword(char[] password)
        {
            int passwordLength = password.Length;

            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = GetRandomIndex(passwordLength);
                char temp = password[i];
                password[i] = password[randomIndex];
                password[randomIndex] = temp;
            }
        }
    }
}
