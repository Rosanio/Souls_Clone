﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemyAttacker : MonoBehaviour
    {
        public EnemyAttackAction[] enemyAttacks;

        EnemyManager enemyManager;
        EnemyAnimatorHandler animatorHandler;

        EnemyAttackAction currentAttack;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            animatorHandler = GetComponentInChildren<EnemyAnimatorHandler>();
            Random.InitState((int)System.DateTime.Now.Ticks);
        }

        public void Attack()
        {
            animatorHandler.anim.SetFloat("Vertical", 0, 0.01f, Time.deltaTime);
            animatorHandler.anim.SetFloat("Horizontal", 0, 0.01f, Time.deltaTime);
            animatorHandler.PlayTargetAnimation(currentAttack.actionAnimation, true);
            enemyManager.isPerformingAction = true;
            enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
            currentAttack = null;
        }

        public void QueueNextAttack(float distanceToTarget)
        {
            if (currentAttack != null) return;

            GetNewAttack(distanceToTarget);
        }

        public bool IsAbleToAttack()
        {
            return currentAttack != null &&
                enemyManager.currentRecoveryTime <= 0 &&
                !enemyManager.isPerformingAction;
        }

        public bool IsInAttackRange(float distanceFromTarget, float viewableAngle)
        {
            if (currentAttack == null) return false;

            return distanceFromTarget < currentAttack.maximumDistanceNeededToAttack &&
                    distanceFromTarget > currentAttack.minimumDistanceNeededToAttack &&
                    viewableAngle < currentAttack.maximumAttackAngle &&
                    viewableAngle > currentAttack.minimumAttackAngle;
        }

        public bool IsCloseEnoughToAttack(float distanceFromTarget)
        {
            if (currentAttack == null) return false;
            return distanceFromTarget <= currentAttack.maximumDistanceNeededToAttack;
        }

        public bool IsTooCloseToAttack(float distanceFromTarget)
        {
            if (currentAttack == null) return false;
            return distanceFromTarget < currentAttack.minimumDistanceNeededToAttack;
        }

        public bool IsWithinAttackAngle(float angle)
        {
            if (currentAttack == null) return false;
            return angle > currentAttack.minimumAttackAngle && angle < currentAttack.maximumAttackAngle;
        }

        public void GetNewAttack(float distanceFromTarget)
        {

            int maxScore = 0;

            foreach(EnemyAttackAction attack in enemyAttacks)
            {
                if (distanceFromTarget > attack.minimumDistanceNeededToAttack)
                {
                    maxScore += attack.attackScore;
                }
            }

            int randomValue = Random.Range(0, maxScore);
            int temporaryScore = 0;

            foreach(EnemyAttackAction attack in enemyAttacks)
            {
                if (distanceFromTarget > attack.minimumDistanceNeededToAttack)
                {
                    temporaryScore += attack.attackScore;

                    if (temporaryScore >= randomValue)
                    {
                        currentAttack = attack;
                        return;
                    }
                }
            }
        }
    }
}
