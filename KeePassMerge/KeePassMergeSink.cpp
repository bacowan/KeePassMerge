#include "pch.h"
#include <windows.h>
#include <shobjidl.h>
#include <shlobj.h>
#include <cstdint>

class KeePassMergeSink : public IFileOperationProgressSink {
private:
    uint32_t volatile* m_cRef = 0;
public:
    HRESULT QueryInterface(
        REFIID   riid,
        LPVOID* ppvObj)
    {
        // Always set out parameter to NULL, validating it first.
        if (!ppvObj)
            return E_INVALIDARG;
        *ppvObj = NULL;
        if (riid == IID_IUnknown || riid == IID_IFileOperation)
        {
            // Increment the reference count and return the pointer.
            *ppvObj = (LPVOID)this;
            AddRef();
            return NOERROR;
        }
        return E_NOINTERFACE;
    }

    ULONG AddRef()
    {
        return InterlockedIncrement(m_cRef);
    }

    ULONG Release()
    {
        // Decrement the object's internal counter.
        ULONG ulRefCount = InterlockedDecrement(m_cRef);
        if (0 == ulRefCount)
        {
            delete this;
        }
        return ulRefCount;
    }

    HRESULT PreCopyItem(
        DWORD      dwFlags,
        IShellItem* psiItem,
        IShellItem* psiDestinationFolder,
        LPCWSTR    pszNewName
    ) {
        int result = MessageBoxW(
            nullptr,
            L"Hello World!",
            L"Custom Copy Handler",
            MB_YESNOCANCEL | MB_ICONQUESTION
        );
        return S_OK;
    }
};