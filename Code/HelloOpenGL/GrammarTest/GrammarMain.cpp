#include <iostream> 
#include <iomanip>
#include <direct.h>

#define random01 (rand()/double(RAND_MAX))

int main()
{
	//C++�鿴ϵͳ��ǰĿ¼
	char buffer[_MAX_PATH];
	_getcwd(buffer, _MAX_PATH);
	std::cout << buffer << std::endl;
	system("Pause");
	return -1;
}


