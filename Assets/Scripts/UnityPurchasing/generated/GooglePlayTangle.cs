// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("I5bw1RMPR6izsS0AyVRGxDbbfNO6sALpQEK2Qi+oojP2+QE5ot3+kHMwfElp5EUkDfRLHcV+qrHP8mhxf/zy/c1//Pf/f/z8/Vjf/Zv3Cpg4XJHSs5Pnb+dJ/MhzFgzs9qVpGs1//N/N8Pv013u1ewrw/Pz8+P3+pKFNnh/gA9oua/MBdkz+Wi0Bh9NOyLxPW/20ycswCxmcSZP9BZnS5dQJMBsH7p+xHXZn6OQBd2e1K5WhiMr/TR09sKIR7VgDs7BmV2N6wSS/BIANkaUF4wkaqczyMFV6NZlxCttLi+4jbakN11pPAZBhkVN9tUtHufislGoFOatXJ9+yP4nixYt/oCvYR7/ewIwbyep6om2li585vlx3tW/E5D07QWBv1v/+/P38");
        private static int[] order = new int[] { 7,4,13,4,12,7,6,10,12,11,12,13,12,13,14 };
        private static int key = 253;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
