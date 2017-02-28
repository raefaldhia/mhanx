#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include <map>
#include <iostream>

#include <sqlite3.h>

std::multimap<std::string, std::string> list;

int main(int argc, char *argv[]) {
	if (argc > 1) {
		if (strcmp(argv[1], "lists") == 0) {
			std::cout << "TODO";
		}
		else if (strcmp(argv[1], "import") == 0) {
			if (argc > 2) {
				for (int i = 2; i < argc; i++) {
					list.insert(std::pair<std::string, std::string>(argv[i], "Example filename"));
				}
			}
			else {
				std::cout << "list import [<target>]";
			}
		}
	}

	return 0;
}