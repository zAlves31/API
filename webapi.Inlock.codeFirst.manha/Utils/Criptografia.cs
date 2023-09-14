namespace webapi.Inlock.codeFirst.manha.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que recebera uma Hash</param>
        /// <returns>Senha Criptografada</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada e igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha Informada pelo usuario</param>
        /// <param name="senhaBanco">Senha Cadastrada no banco</param>
        /// <returns>True ou False (senha e verdadeira ?)</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
