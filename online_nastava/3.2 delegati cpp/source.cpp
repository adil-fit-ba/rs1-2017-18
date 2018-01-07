#include<iostream>

using namespace std;
typedef void(*PokTip)(int);

void F(PokTip p)
{
	int a;
	cin >> a;
	p(a);
}

void main()
{
	F([](int a) { cout << "a = " << a << endl; });
	F([](int a) { cout << "a*a = " << a*a << endl; });
	F([](int a) { cout << "a*a*a = " << a*a*a << endl; });
	F([](int a) { cout << "a*35 = " << pow(a,35) << endl; });
}