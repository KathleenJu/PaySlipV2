using System.Collections;
using System.Collections.Generic;

namespace PaySlip.FilesConfig
{
    interface FileConfigInterface
    {
        IEnumerable Foo(string fileContent);
    }
}