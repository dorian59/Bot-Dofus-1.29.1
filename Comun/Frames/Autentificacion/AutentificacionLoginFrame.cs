﻿using Bot_Dofus_1._29._1.Comun.Frames.Transporte;
using Bot_Dofus_1._29._1.Comun.Network;
using System.Text;

namespace Bot_Dofus_1._29._1.Comun.Frames.Autentificacion
{
    class AutentificacionLogin : Frame
    {
        [PaqueteAtributo("AlEf")]
        public void get_Error_Datos(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("LOGIN", "Connexion rejetée. Nom de compte ou mot de passe incorrect.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("AlEa")]
        public void get_Error_Ya_Conectado(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("LOGIN", "Déjà connecté Essaye à nouveau.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("AlEv")]
        public void get_Error_Version(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("LOGIN", "La version %1 Dofus que vous avez installé n'est pas compatible avec ce serveur. Pour jouer, installez la version % 2. Le client DOFUS va fermer.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("AlEb")]
        public void get_Error_Baneado(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("LOGIN", "Connexion rejetée. Votre compte a été banni.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("AlEd")]
        public void get_Error_Conectado(ClienteTcp cliente, string paquete)
        {
            cliente.cuenta.logger.log_Error("LOGIN", "Ce compte est déjà connecté à un serveur de jeux. Veuillez réessayer.");
            cliente.cuenta.desconectar();
        }

        [PaqueteAtributo("AlEk")]
        public void get_Error_Baneado_Tiempo(ClienteTcp cliente, string paquete)
        {
            string[] informacion_ban = paquete.Substring(3).Split('|');
            int dias = int.Parse(informacion_ban[0].Substring(1)), horas = int.Parse(informacion_ban[1]), minutos = int.Parse(informacion_ban[2]);
            StringBuilder mensaje = new StringBuilder().Append("Votre compte sera invalide pendant ");

            if (dias > 0)
                mensaje.Append(dias + " jours");
            if (horas > 0)
                mensaje.Append(horas + " heures");
            if (minutos > 0)
                mensaje.Append(minutos + " minutes");

            cliente.cuenta.logger.log_Error("LOGIN", mensaje.ToString());
            cliente.cuenta.desconectar();
        }
    }
}
