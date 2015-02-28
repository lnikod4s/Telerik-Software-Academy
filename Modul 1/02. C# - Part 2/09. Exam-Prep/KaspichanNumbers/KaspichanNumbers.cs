using System;
using System.Collections.Generic;

class KaspichanNumbers
{
	/// <summary>
	/// C# Part 2 - 2012/2013 @ 4 Feb 2013 - Morning
	/// 1. Kaspichan Numbers
	/// </summary>
	static string[] alpha =
		{
			"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "aA", "aB", "aC", "aD", "aE", "aF", "aG", "aH", "aI", "aJ", "aK", "aL", "aM", "aN", "aO", "aP", "aQ", "aR", "aS", "aT", "aU", "aV", "aW", "aX", "aY", "aZ", "bA", "bB", "bC", "bD", "bE", "bF", "bG", "bH", "bI", "bJ", "bK", "bL", "bM", "bN", "bO", "bP", "bQ", "bR", "bS", "bT", "bU", "bV", "bW", "bX", "bY", "bZ", "cA", "cB", "cC", "cD", "cE", "cF", "cG", "cH", "cI", "cJ", "cK", "cL", "cM", "cN", "cO", "cP", "cQ", "cR", "cS", "cT", "cU", "cV", "cW", "cX", "cY", "cZ", "dA", "dB", "dC", "dD", "dE", "dF", "dG", "dH", "dI", "dJ", "dK", "dL", "dM", "dN", "dO", "dP", "dQ", "dR", "dS", "dT", "dU", "dV", "dW", "dX", "dY", "dZ", "eA", "eB", "eC", "eD", "eE", "eF", "eG", "eH", "eI", "eJ", "eK", "eL", "eM", "eN", "eO", "eP", "eQ", "eR", "eS", "eT", "eU", "eV", "eW", "eX", "eY", "eZ", "fA", "fB", "fC", "fD", "fE", "fF", "fG", "fH", "fI", "fJ", "fK", "fL", "fM", "fN", "fO", "fP", "fQ", "fR", "fS", "fT", "fU", "fV", "fW", "fX", "fY", "fZ", "gA", "gB", "gC", "gD", "gE", "gF", "gG", "gH", "gI", "gJ", "gK", "gL", "gM", "gN", "gO", "gP", "gQ", "gR", "gS", "gT", "gU", "gV", "gW", "gX", "gY", "gZ", "hA", "hB", "hC", "hD", "hE", "hF", "hG", "hH", "hI", "hJ", "hK", "hL", "hM", "hN", "hO", "hP", "hQ", "hR", "hS", "hT", "hU", "hV", "hW", "hX", "hY", "hZ", "iA", "iB", "iC", "iD", "iE", "iF", "iG", "iH", "iI", "iJ", "iK", "iL", "iM", "iN", "iO", "iP", "iQ", "iR", "iS", "iT", "iU", "iV", "iW", "iX", "iY", "iZ" 
		};
	static void Main()
	{
		ulong inputNumber = ulong.Parse(Console.ReadLine());

		// Convert the input decimal number to number in 256 base system)
		List<string> kaspichanNumbers = new List<string>();
		do
		{
			kaspichanNumbers.Add(alpha[inputNumber % 256]);
			inputNumber /= 256;
		}
		while (inputNumber != 0);

		kaspichanNumbers.Reverse(); // Reversing the number to get the real value
		string result = string.Join(string.Empty, kaspichanNumbers);

		Console.WriteLine(result);
	}
}