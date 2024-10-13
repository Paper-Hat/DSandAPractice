using System.Text;

namespace DSandAPractice.AlgorithmsAndConcepts;

public static class BitManipulation
{
    //Returns bit at position given 1:true, 0:false
    public static bool GetBit(int num, int pos)
    {
        return (num & (1 << pos)) > 0;
    }
    
    //ANDs the number with a left-shifted 1 and inverts it to zero out the position
    public static int ClearBit(int num, int pos)
    {
        return num & ~(1 << pos);
    }

    //Clears bits from the left (most significant bit) up to the position
    //Left-shifts 1 by the position, subtracting one from it to get leading series of 1s
    public static int ClearMSB(int num, int pos)
    {
        return num & ((1 << pos) - 1);
    }
    
    //Clear bits from least significant bit including the position
    //Left-shift a series of ones (-1) and AND it with the number
    public static int ClearLSB(int num, int pos)
    {
        return num & (-1 << (pos + 1));
    }

    //Sets bit at position to value of isOne param by first clearing the bit, then ORing it after left-shifting the set
    //by the position
    public static int SetBit(bool isOne, int num, int pos)
    {
        int toSet = (isOne) ?  1 : 0;
        return (num & ~(1 << pos)) | (toSet << pos);
    }

    //Returns bit representation of the number for 32 bit integer
    public static string BitString(Int32 num)
    {
        StringBuilder sb = new StringBuilder();
        int bitVal;
        for (int i = 31; i >= 0; i--) {
            bitVal = GetBit(num, i) ? 1 : 0;
            sb.AppendFormat("{0} ", bitVal);
        }
        
        return sb.ToString();
    }
}