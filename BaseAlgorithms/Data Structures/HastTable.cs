using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.Data_Structures
{
    public class HastTable
    {
        private const int size = 1_000_000;
        private const  int HasTableSize = size;

        HashItem?[] hashArray = new HashItem?[size];

        /* 8-bit index 
        typedef unsigned char HashIndexType;
        static const int HashIndexType K = 158;
        */

        /* 16-bit index 
        typedef unsigned short int HashIndexType;*/
        const int K = 40503;


        /* 32-bit index 
        typedef unsigned long int HashIndexType;
        const long K = 2654435769;*/

        /* w=bitwidth(HashIndexType), size of table=2**m */
        const int S = 16 - HasTableSize;

        public int Hash(int key) => K * key >> S;

        public void Insert(int key, int data)
        {
            var item = new HashItem
            {
                Data = data,
                Key = key
            };

            //get the hash 
            int hashIndex = Hash(key);

            //move in array until an empty or deleted cell
            while(hashArray[hashIndex] != null) {
                //go to next cell
                ++hashIndex;
		
                //wrap around the table
                hashIndex %= size;
            }

            hashArray[hashIndex] = item;
        }

        public HashItem? Search(int key)
        {
            //get the hash 
            var hashIndex = Hash(key);

            //move in array until an empty 
            while (hashArray[hashIndex] != null)
            {
                if (hashArray[hashIndex]?.Key == key)
                    return hashArray[hashIndex];

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= size;
            }

            return null;
        }

        public void Delete(HashItem item) {
            var key = item.Key;

            //get the hash 
            var hashIndex = Hash(key);

            //move in array until an empty
            while(hashArray[hashIndex] != null) {
	
                if(hashArray[hashIndex]?.Key == key) {
                    var temp = hashArray[hashIndex]; 
			
                    //assign a dummy item at deleted position
                    hashArray[hashIndex] = null; 
                    return;
                }
		
                //go to next cell
                ++hashIndex;
		
                //wrap around the table
                hashIndex %= size;
            }      
        }

    }

    public struct HashItem
    {
        public int Key { get; set; }
        public int Data { get; set; }
    }
}
