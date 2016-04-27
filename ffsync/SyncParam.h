#pragma once
#include <string>
class SyncParam
{
public:
	enum Type{
		Unknown,
		CopyToDest,									// just copy
		SyncDestFromSource,							// common way sync
		SyncJoinSourceAndDest,						// just add new files in both directions
		DeleteFileDublicatesInSource,				// delete same files in source
		DeleteDublicatesFromSourceInDestination,	// delete same files from source in Destination		
	};
private:
	std::string src;
	std::string dest;
	Type type;
public:	
	SyncParam(){};
	~SyncParam(){};	
};

