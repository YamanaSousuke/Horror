using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Horror
{
    // �ړ�����L�����N�^�[�Ɍp������C���^�[�t�F�[�X
    public interface ICharacterMovement
    {
        // �ꏊ���؂�ւ�����Ƃ��ɍ��W�Ɖ�]��ݒ肷��
        public void SetTransform(Vector3 position, Vector3 direction);
    }
}

