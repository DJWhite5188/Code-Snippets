#include <iostream>
#include <fstream>
#include <string>
#include <vector>;
using namespace std;
//these will hold the seperated data
vector<string> zero;
vector<string> one;
vector<string> two;
vector<string> three;
vector<string> four;
vector<string> five;
vector<string> six;
vector<string> seven;


string a = "PO Number: ";
string b = "Manufacturer: ";
string c = "Customer: ";
string d = "Price: ";
string e = "Earnings: ";
string f = "Date and Time: ";

//what each individual cell will represent 
string partNumber;
string Manufacturer;
string custOrDist;
string status;
string price;
string earnings;
string date;
string space = ".........";



//price total for each status set
float ptotal0 = 0;
float ptotal1 = 0;
float ptotal2 = 0;
float ptotal3 = 0;
float ptotal4 = 0;
float ptotal5 = 0;
float ptotal6 = 0;
float ptotal7 = 0;


//earning total for each status set
float etotal0 = 0;
float etotal1 = 0;
float etotal2 = 0;
float etotal3 = 0;
float etotal4 = 0;
float etotal5 = 0;
float etotal6 = 0;
float etotal7 = 0;


//this function will be used to add data into vector and calculate price and earnings total
void AddToVector(vector<string> &vector, float &ptotal, float &etotal) 
{
	    
	    
		vector.push_back(a + partNumber);
		vector.push_back(b + Manufacturer);
		vector.push_back(c + custOrDist);
		vector.push_back(d + price);
		vector.push_back(e + earnings);
		vector.push_back(f + date);
		vector.push_back(space);
		ptotal += stof(price);
		etotal += stof(earnings);
		
	
}
void read()
{
	

	//opens file and checks if its there
	ifstream file;
	file.open("Data.csv");
	if (file.fail())
	{
		cout << "data not found in file";
	}
	//ignores the first line of the file
	file.ignore(500, '\n');

	//reads the file and seperates each cell 
	while (file.good())
	{ 
		
		getline(file, partNumber, ',');
		getline(file, Manufacturer, ',');
		getline(file, custOrDist, ',');                
		getline(file, status, ',' );
		getline(file, price, ',');
		getline(file, earnings, ',');
		getline(file, date, '\n');
	

	
		
		
		if (stoi(status) == 0)
		{
			AddToVector(zero, ptotal0, etotal0);
		}
		
		if (stoi(status) == 1)
		{                                                          //implements add to vector function and adds data into appropriate vector based off status
			AddToVector(one, ptotal1, etotal1);
		}
		if (stoi(status) == 2)
		{
			AddToVector(two, ptotal2, etotal2);
		}
		if (stoi(status) == 3)
		{
			AddToVector(three, ptotal3, etotal3);
		}
		if (stoi(status) == 4)
		{
			AddToVector(four, ptotal4, etotal4);
		}
		if (stoi(status) == 5)
		{
			AddToVector(five, ptotal5, etotal5);
		}
		if (stoi(status) == 6)
		{
			AddToVector(six, ptotal6, etotal6);
		}
		if (stoi(status) == 7)
		{
			AddToVector(seven, ptotal7, etotal7);
		}
		
   	}

}

//this function prints out the contents of a vector along with associated earnings total and cost total
void Print(float earningsTotal, float costTotal, vector<string> const &vector)
{
	for (int i = 0; i < vector.size(); i++)     
	{
		cout << vector.at(i) << '\n';
		cout << "\n";
	}
	
	cout << "Total Earnings: " << earningsTotal << "\n";
	cout << "Total Cost: " << costTotal <<  "\n";
	cout << "\n\n\n";
	
}

int main()
{
	read();
	
	cout << "****************New********************" << "\n\n";
	Print(ptotal0, etotal0, zero);
	

	cout << "****************Hold For Release****************" << "\n\n";           
	Print(ptotal1, etotal1, one);

	cout << "****************Scheduled****************" << "\n\n";
	Print(ptotal2, etotal2, two);
	                                                                              //prints the contents of each vector vector along with 
	cout << "****************Shipped****************" << "\n\n";	
	Print(ptotal3, etotal3, three);

	cout << "****************Invoiced****************" << "\n\n";
	Print(ptotal4, etotal4, four);

	cout << "****************Closed****************" << "\n\n";
	Print(ptotal5, etotal5, five);

	cout << "***************Acknowledged****************" << "\n\n";
	Print(ptotal6, etotal6,six);

	cout << "****Cancelled****" << "\n\n";
	Print(ptotal7, etotal7, seven);
}