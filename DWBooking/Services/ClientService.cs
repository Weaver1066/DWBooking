using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.Services
{
    public class ClientService
    {
        private GenericDbService<Client> DbService { get; set; }

        //List is made static as there is no instance where a user require their own instance of the list.
        public static List<Client> ClientList { get; set; }

        public ClientService(GenericDbService<Client> dbService)
        {
            DbService = dbService;
            //ClientList = MockData.MockClients.GetMockClients();
            //foreach (Client e in ClientList)
            //{
            //    DbService.AddObjectAsync(e);
            //}
            ClientList = DbService.GetObjectsAsync().Result.ToList();
        }

        /// <summary>
        /// Adds event to the database and to the services eventlist
        /// </summary>
        /// <param name="client">the event to be added</param>
        /// <returns></returns>
        public async Task AddClientAsync(Client client)
        {
            ClientList.Add(client);
            await DbService.AddObjectAsync(client);
        }

        public IEnumerable<Client> GetClients()
        {
            return ClientList;
        }
        /// <summary>
        /// Checks the database and returns a client if it exists.
        /// </summary>
        /// <param name="phone">the event to be added</param>
        /// <returns></returns>
        public Client CheckPhone(string phone)
        {
            foreach (var client in ClientList)
            {
                if (client.Phone == phone)
                {
                    return client;
                }
            }

            return null;
        }


        /// <summary>
        /// takes the client id as integer and returns the client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the client with the given id</returns>
        public Client GetClientById(int id)
        {
            foreach (var c in ClientList)
            {
                if (c.ClientID == id)
                {
                    return c;
                }
            }

            return null;
        }


        /// <summary>
        /// Searches the service list for the client with the given string as a name or phone number
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns the client with the given phone number or name</returns>
        public Client SearchClientName(string name)
        {
            foreach (var client in ClientList)
            {
                if (client.Name.ToLower() == name.ToLower() || client.Phone == name)
                {
                    return client;
                }
            }

            return null;
        }


        /// <summary>
        /// searches the service list for clients who's names contains the given string
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a list of clients who's names contains the given string</returns>
        public IEnumerable<Client> SearchClientsByName(string name)
        {
            List<Client> temp = new List<Client>();
            foreach (var client in ClientList)
            {
                if (client.Name.ToLower().Contains(name.ToLower()))
                {
                    temp.Add(client);
                }
            }

            return temp;
        }

        /// <summary>
        /// updates the given client in the database and service list
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateClientAsync(Client e)
        {
            if (e != null)
            {
                foreach (Client i in ClientList)
                {
                    if (i.ClientID == e.ClientID)
                    {
                        i.Name = e.Name;
                        i.Email = e.Email;
                        i.Phone = e.Phone;
                    }
                }
                await DbService.UpdateObjectAsync(e);
            }
        }
    }
}
