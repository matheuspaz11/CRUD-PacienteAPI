namespace CRUD_PacienteAPI.Helpers.Validators
{
    public class ValidateCPF
    {
        public static bool IsValidCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !IsNumeric(cpf))
            {
                return false;
            }

            bool allDigitsEqual = true;

            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    allDigitsEqual = false;
                    break;
                }
            }
            if (allDigitsEqual)
            {
                return false;
            }

            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCPF = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCPF[i].ToString()) * multiplier1[i];
            }

            int remainder = sum % 11;
            int digit1 = (remainder < 2) ? 0 : (11 - remainder);

            tempCPF += digit1;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCPF[i].ToString()) * multiplier2[i];
            }

            remainder = sum % 11;
            int digit2 = (remainder < 2) ? 0 : (11 - remainder);

            return cpf.EndsWith(digit1.ToString() + digit2.ToString());
        }

        private static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}