# Merganader



## Screenshot

[![CSV Template Merganader Screenshot](http://i.imgur.com/tbM0y21.jpg)]

## Installation



## Requirements
.NET Framework


## Usage
1. Load a CSV (1data.csv)
2. Load a Template (2template.txt)
3. push generate. 
4. Save the output. 

The app uses the first row of the CSV as variable names.
You can double click the variable list in the left listbox and it adds them to the template box.
Any instance of the <<var>> string will be replaced with the row's column.  
For instance, <<team>><<team>><<team>><<team>><<team>> would result
in an output of :
alphaalphaalphaalphaalpha
bravobravobravobravobravo
charliecharliecharliecharliecharlie


## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History/Changelog

As of 5/22 - the code is working very well.


## Future/To-Do

1. Separate form code into a dll.
2. Allow command line calls
3. Template specials (split output into files by row, allow some basic logic)



## License

GNU GPL v2
Copyright (C) 2015 Termanader

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
