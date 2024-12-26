public static class NumberToWordsConverter
{
    private static readonly string[] UnitsMap = { "صفر", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
    private static readonly string[] TensMap = { "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
    private static readonly string[] TeensMap = { "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
    private static readonly string[] ScaleMap = { "", "ألف", "مليون", "مليار", "تريليون" };

    public static string ConvertAmountToWords(decimal amount)
    {
        if (amount == 0)
            return UnitsMap[0];

        int dinars = (int)amount;
        int fils = (int)((amount - dinars) * 100);

        string dinarsInWords = ConvertToWords(dinars);
        string filsInWords = ConvertToWords(fils);

        return $"{dinarsInWords} دينار و {filsInWords} فلس";
    }

    private static string ConvertToWords(int number)
    {
        if (number == 0)
            return UnitsMap[0];

        string words = "";

        int scale = 0;

        while (number > 0)
        {
            int chunk = number % 1000;
            if (chunk > 0)
            {
                string chunkWords = ConvertChunkToWords(chunk);
                if (scale > 0 && !string.IsNullOrEmpty(chunkWords))
                {
                    chunkWords += $" {ScaleMap[scale]}";
                }

                words = string.IsNullOrEmpty(words) ? chunkWords : $"{chunkWords} و {words}";
            }

            number /= 1000;
            scale++;
        }

        return words;
    }

    private static string ConvertChunkToWords(int number)
    {
        if (number == 0)
            return "";

        string chunkWords = "";

        if (number / 100 > 0)
        {
            chunkWords += $"{UnitsMap[number / 100]} مائة";
            number %= 100;

            if (number > 0)
            {
                chunkWords += " و ";
            }
        }

        if (number >= 20)
        {
            chunkWords += TensMap[number / 10 - 1];
            number %= 10;

            if (number > 0)
            {
                chunkWords += $" و {UnitsMap[number]}";
            }
        }
        else if (number >= 11)
        {
            chunkWords += TeensMap[number - 11];
        }
        else if (number > 0)
        {
            chunkWords += UnitsMap[number];
        }

        return chunkWords;
    }
}
