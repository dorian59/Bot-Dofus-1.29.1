using Bot_Dofus_1._29._1.Comun.Frames.Transporte;
using Bot_Dofus_1._29._1.Comun.Network;


namespace Bot_Dofus_1._29._1.Comun.Frames.Juego
{
    class AutentificacionJuego : Frame
    {
        [PaqueteAtributo("M030")]
        public void get_Error_Streaming(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("Login", "Connexion rejetée. Vous ne pouvez pas vous authentifier pour ce serveur car votre connexion a expiré. Assurez-vous de couper les téléchargements, ainsi que la musique ou les vidéos en streaming, afin d'améliorer la qualité et la vitesse de votre connexion.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("M031")]
        public void get_Error_Red(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("Login", "Connexion rejetée. Le serveur de jeu n'a pas reçu les informations d'authentification nécessaires après votre identification. Veuillez réessayer et, si le problème persiste, contactez votre administrateur réseau ou votre serveur d'accès Internet. Il s'agit d'un problème de nouvelle adresse en raison d'une mauvaise configuration DNS.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("M032")]
        public void get_Error_Flood_Conexion(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("Login", "Pour éviter de gêner les autres joueurs, attendez %1 secondes avant de vous reconnecter.");
            cliente.cuenta.desconectar();
        }
    }
}
